using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;

namespace JVCCamcoder {
	public class JVCCamcoderResponseParser : MonoBehaviour {

		[SerializeField] JVCCamcoderStatus CamcoderStatus;

		public bool Parse(string cameraResponse) {
			Dictionary<string, object> dict = Json.Deserialize(cameraResponse) as Dictionary<string, object>;
			if (!dict.ContainsKey("Response")) return false;
			Dictionary<string, object> Response = dict["Response"] as Dictionary<string, object>;
			if (!Response.ContainsKey("Result")) return false;
			if (((string)Response["Result"]) != "Success") return false;
			if (Response.ContainsKey("Requested")) {
				if ((string)Response["Requested"] == "GetCamStatus") {
					ParseCamStatus(Response["Data"] as Dictionary<string, object>);
				}
			}
			return true;
		}

		private void ParseCamStatus(Dictionary<string, object> dict) {
			CamcoderStatus.CameraDictionary = dict["Camera"] as Dictionary<string, dynamic>;
			CamcoderStatus.FullAutoDictionary = dict["Fullauto"] as Dictionary<string, dynamic>;
			CamcoderStatus.IrisDictionary = dict["Iris"] as Dictionary<string, dynamic>;
			CamcoderStatus.GainDictionary = dict["Gain"] as Dictionary<string, dynamic>;
			CamcoderStatus.AeLevelDictionary = dict["AeLevel"] as Dictionary<string, dynamic>;
			CamcoderStatus.ShutterDictionary = dict["Shutter"] as Dictionary<string, dynamic>;
			CamcoderStatus.WhbDictionary = dict["Whb"] as Dictionary<string, dynamic>;
			CamcoderStatus.ZoomDictionary = dict["Zoom"] as Dictionary<string, dynamic>;
			CamcoderStatus.FocusDictionary = dict["Focus"] as Dictionary<string, dynamic>;
			CamcoderStatus.MasterBlackDictionary = dict["MasterBlack"] as Dictionary<string, dynamic>;
			CamcoderStatus.DetailDictionary = dict["Detail"] as Dictionary<string, dynamic>;
			CamcoderStatus.StreamingDictionary = dict["Streaming"] as Dictionary<string, dynamic>;
			CamcoderStatus.DispTvDictionary = dict["Disptv"] as Dictionary<string, dynamic>;
			CamcoderStatus.CharacterMixDictionary = dict["CharacterMix"] as Dictionary<string, dynamic>;
			CamcoderStatus.TallyLampDictionary = dict["TallyLamp"] as Dictionary<string, dynamic>;
			CamcoderStatus.SlotADictionary = dict["SlotA"] as Dictionary<string, dynamic>;
			CamcoderStatus.SlotBDictionary = dict["SlotB"] as Dictionary<string, dynamic>;
			CamcoderStatus.BatteryDictionary = dict["Battery"] as Dictionary<string, dynamic>;
			Dictionary<string, dynamic> tmpEnableDict = dict["Enable"] as Dictionary<string, dynamic>;

			CamcoderStatus.EnableFullAutoDictionary = tmpEnableDict["Fullauto"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableIrisDictionary = tmpEnableDict["Iris"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableGainDictionary = tmpEnableDict["Gain"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableAeLevelDictionary = tmpEnableDict["AeLevel"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableShutterDictionary = tmpEnableDict["Shutter"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableWhbDictionary = tmpEnableDict["Whb"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableZoomDictionary = tmpEnableDict["Zoom"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableFocusDictionary = tmpEnableDict["Focus"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableMasterBlackDictionary = tmpEnableDict["MasterBlack"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableDetailDictionary = tmpEnableDict["Detail"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableUserDictionary = tmpEnableDict["User"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableStreamingDictionary = tmpEnableDict["Streaming"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableDispTvDictionary = tmpEnableDict["Disptv"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableCharacterMixDictionary = tmpEnableDict["CharacterMix"] as Dictionary<string, dynamic>;
			CamcoderStatus.EnableMenuDictionary = tmpEnableDict["Menu"] as Dictionary<string, dynamic>;

			Dictionary<string, dynamic> tmpButtonStringDict = dict["ButtonString"] as Dictionary<string, dynamic>;
			CamcoderStatus.ButtonStringGainDictionary = tmpButtonStringDict["Gain"] as Dictionary<string, dynamic>;
			CamcoderStatus.ButtonStringUserDictionary = tmpButtonStringDict["User"] as Dictionary<string, dynamic>;
			CamcoderStatus.ButtonStringWhbDictionary = tmpButtonStringDict["Whb"] as Dictionary<string, dynamic>;
		}
	}
}
