using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;

public enum Enable {
	Disable = 0,
	Enable
}

namespace JVCCamcoder {
	public class JVCCamcoderAPIManager : MonoBehaviour {
		[SerializeField] public JVCCamcoderStatus CamcoderStatus;
		[SerializeField] private JVCCamcoderResponseParser ResponsePerser;
		[SerializeField] private string camCoderIPAddress;
		[SerializeField] private int port = 80;
		[SerializeField] private string userID = "jvc";
		[SerializeField] private string password = "0000";

		private string entryPoint = "";
		private int nc = 1;
		private string cnonce;
		private string realm;
		private string nonce;
		private string qop;
		private string authValue = "";
		private string sessionID = "";
		private string wwwAuthenticate;
		private bool isAuthenticateSuccess = false;
		private int frameCount = 0;

		IEnumerator Start() {
			realm = "";
			nonce = "";
			qop = "";

			if (camCoderIPAddress == null || camCoderIPAddress == "")
				yield break;

			entryPoint = "/api.php";
			UnityWebRequest getRequest = UnityWebRequest.Get("http://" + camCoderIPAddress + entryPoint);
			UnityWebRequest.ClearCookieCache();
			yield return getRequest.Send();

			if (getRequest.isNetworkError) {
				Debug.Log(getRequest.error);
			}
			else {

				if (getRequest.responseCode == 200) {
					var resps = getRequest.GetResponseHeaders();
					foreach (KeyValuePair<string, string> kvp in resps) {
						Debug.Log(kvp.Value);
					}
				}
				else if (getRequest.responseCode == 401) {
					var resps = getRequest.GetResponseHeaders();
					foreach (KeyValuePair<string, string> kvp in resps) {
						if (kvp.Key == "WWW-Authenticate") {
							UnityWebRequest authRequest =
								UnityWebRequest.Get("http://" + camCoderIPAddress + entryPoint);

							var vals = kvp.Value.Replace("\"", "").Split(',');
							foreach (var val in vals) {
								var tmps = val.Split('=');
								if (tmps[0].Contains("realm")) realm = tmps[1];
								else if (tmps[0].Contains("nonce")) nonce = tmps[1];
								else if (tmps[0].Contains("qop")) qop = tmps[1];
							}

							cnonce = "cnonce";
							wwwAuthenticate = kvp.Value;
							authValue = BuildAuthrizeHeader("GET", entryPoint);
							authRequest.SetRequestHeader("Authorization", authValue);
							yield return authRequest.Send();

							if (authRequest.responseCode == 200) {
								var respHeads = authRequest.GetResponseHeaders();
								foreach (KeyValuePair<string, string> header in respHeads) {
									var elements = header.Value.Split(',');
									foreach (var element in elements) {
										if (element.Contains("SessionID")) {
											sessionID = element.Split('=')[1];
											break;
										}
									}
								}

								if (sessionID != "") {
									entryPoint = "/cgi-bin/api.cgi";
									isAuthenticateSuccess = true;
								}
							}
						}
					}
				}
			}
		}

		// Update is called once per frame
		void Update() {
			if (isAuthenticateSuccess == false)
				return;

			if ((frameCount % 6) == 0) {
				StartCoroutine(QueryCameraStatus());
			}
			else {
				frameCount++;
			}
		}

		IEnumerator QueryCameraStatus() {
			string sendJSONData = BuildRequestBody("GetCamStatus", null, sessionID);
			Debug.Log(sendJSONData);
			var apireq = BuildAPIWebRequest("/cgi-bin/api.cgi", sendJSONData);
			frameCount++;
			yield return apireq.Send();
			if (apireq.responseCode == 200) {
				ResponsePerser.Parse(apireq.downloadHandler.text);
			}
		}

		public IEnumerator ZoomSwitchOperation(string direction, int speed) {
			Dictionary<string, dynamic>paramDict = new Dictionary<string, dynamic>();
			paramDict.Add("Direction", direction);
			paramDict.Add("Speed", speed);
			string sendJSONData = BuildRequestBody("ZoomSwitchOperation", paramDict, sessionID);
			Debug.Log(sendJSONData);
			var apireq = BuildAPIWebRequest("/cgi-bin/api.cgi", sendJSONData);
			frameCount = 0;
			yield return apireq.Send();
			if (apireq.responseCode == 200) {
			}
		}

		public IEnumerator ZoomSliderOperation(int position ){
			Dictionary<string, dynamic> paramDict = new Dictionary<string, dynamic>();
			paramDict.Add("Kind", "ZoomBar");
			paramDict.Add("Position", position);
			string sendJSONData = BuildRequestBody("SetWebSliderEvent", paramDict, sessionID);
			Debug.Log(sendJSONData);
			var apireq = BuildAPIWebRequest("/cgi-bin/api.cgi", sendJSONData);
			frameCount = 0;
			yield return apireq.Send();
			if (apireq.responseCode == 200) {
			}
		}


		private string BuildAuthrizeHeader(string method, string entryPoint_) {
			string ncStr = nc.ToString("X8");
			var authResp = GetDigestResponse(userID, realm, password, method, entryPoint_, nonce, cnonce, ncStr, qop);
			return wwwAuthenticate +
				   $",username=\"{userID}\"" +
				   $",uri=\"{entryPoint_}\"" +
				   $",response=\"{authResp}\"" +
				   $",nc=\"{ncStr}\"" +
				   $",cnonce=\"{cnonce}\"";
		}

		private string GetDigestResponse(string user_, string realm_, string passwd_, string method_, string uri_,
			string nonce_, string cnonce_, string nc_, string qop_) {
			string a1md5 = CalcMd5($"{user_}:{realm_}:{passwd_}");
			string a2md5 = CalcMd5($"{method_}:{uri_}");
			return CalcMd5($"{a1md5}:{nonce_}:{nc_}:{cnonce_}:{qop_}:{a2md5}");
		}

		private string BuildRequestBody(string command, Dictionary<string, dynamic> parameter, string sessionId) {
			Dictionary<string, dynamic> body = new Dictionary<string, dynamic>();
			body.Add("Command", command);
			if (parameter != null)
				body.Add("Params", parameter);
			body.Add("SessionID", sessionId);
			Dictionary<string, dynamic> retDict = new Dictionary<string, dynamic>();
			retDict.Add("Request", body);
			return Json.Serialize(retDict);
		}

		private UnityWebRequest BuildAPIWebRequest(string entryPoint_, string body) {
			UnityWebRequest apiRequest = new UnityWebRequest("http://" + camCoderIPAddress + entryPoint_, "POST");
			apiRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));
			apiRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
			nc++;
			apiRequest.SetRequestHeader("Authorization", BuildAuthrizeHeader("POST", entryPoint_));
			apiRequest.SetRequestHeader("Content-Type", " application/x-www-form-urlencoded; charset=UTF-8");
			return apiRequest;
		}

		private string CalcMd5(string srcStr) {

			System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] srcBytes = System.Text.Encoding.UTF8.GetBytes(srcStr);
			byte[] destBytes = md5.ComputeHash(srcBytes);

			System.Text.StringBuilder destStrBuilder;
			destStrBuilder = new System.Text.StringBuilder();
			foreach (byte curByte in destBytes) {
				destStrBuilder.Append(curByte.ToString("x2"));
			}

			return destStrBuilder.ToString();
		}
	}
}