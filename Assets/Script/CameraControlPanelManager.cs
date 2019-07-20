using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using JVCCamcoder;
using UnityEngine.UI;

public class CameraControlPanelManager : MonoBehaviour {

	[SerializeField] private JVCCamcoderStatus CamcoderStatus;
	[SerializeField] private JVCCamcoderAPIManager APIManager;
	public readonly int ZOOMMAX = 328;

	private Text zoomText1;
	private Text zoomText2;
	private Text zoomText3;
	private Slider zoomSlider;
	public int zoomPos;
	private bool isMouseDownOnZoomSlider = false;
	private static Dictionary<string, dynamic> oldZoomDict;

	// Start is called before the first frame update
	void Start()
    {
		oldZoomDict = new Dictionary<string, dynamic>();
	    zoomText1 = GameObject.Find("ZoomText1").GetComponent<Text>();
	    zoomText2 = GameObject.Find("ZoomText2").GetComponent<Text>();
	    zoomText3 = GameObject.Find("ZoomText3").GetComponent<Text>();
	    zoomSlider = GameObject.Find("ZoomSlider").GetComponent<Slider>();
	//    zoomPos = 20;
	}

	// Update is called once per frame
	void Update()
    {
		if (CamcoderStatus == null) return;
		Dictionary<string, dynamic> zoomDict = CamcoderStatus.ZoomDictionary;
		UpdateZoomSection(zoomDict);

    }


	private void UpdateZoomSection(Dictionary<string, dynamic> dict) {

		if (RecursiveDictionaryCompare(dict, oldZoomDict) == true) return;
	    if (dict != null) {
		    var posString = ((string) dict["DisplayValue"]).Replace(" ", "");
			zoomPos = (int)dict["Position"];
			zoomText1.text = posString;
		    zoomText2.text = zoomPos.ToString();
		    zoomText3.text = "Dynamic:"+((string)dict["Dynamic"]).ToString();

		    if (isMouseDownOnZoomSlider == false) {
			    var splt = posString.Split('Z');
			    if (splt.Length == 2) {
				    zoomSlider.value = int.Parse(splt[1]);
			    }
		    }
		}
		oldZoomDict = new Dictionary<string, dynamic>(dict);

	}


    private bool RecursiveDictionaryCompare(Dictionary<string, dynamic> dict1, Dictionary<string, dynamic> dict2) {
	    var keys1 = dict1.Keys.ToList();
	    var keys2 = dict2.Keys.ToList();
	    if (keys1.Count != keys2.Count) return false;
	    keys1.Sort();
	    keys2.Sort();
	    for (var i = 0; i < keys1.Count; i++) {
		    if (keys1[i] != keys2[i]) return false;
			
		    object val1 = dict1[keys1[i]];
		    object val2 = dict2[keys2[i]];

		    if (val1.GetType() != val2.GetType()) return false;
		    if (val1.GetType() == typeof(Dictionary<string, dynamic>)) {
			    if (RecursiveDictionaryCompare(dict1 as Dictionary<string, dynamic>,
				        dict2 as Dictionary<string, dynamic>) == false) return false;			
		    }

		    if (val1.GetType() == typeof(string)) {
			    if (!((string)val1).Equals(((string) val2))) return false;
		    }
		    if (val1.GetType() == typeof(int)) {
			    if ((int) val1 != (int) val2) return false;
		    }
		    if (val1.GetType() == typeof(float)) {
			    if ((float)val1 != (float)val2) return false;
		    }
		    if (val1.GetType() == typeof(double)) {
			    if ((double)val1 != (double)val2) return false;
		    }
		    if (val1.GetType() == typeof(bool)) {
			    if ((bool)val1 != (bool)val2) return false;
		    }

		}
		return true;
    }

    #region  zoom_function
	public void onMouseDownZoomSlider() {
	    isMouseDownOnZoomSlider = true;
    }
    public void onMouseUpZoomSlider() {
	    isMouseDownOnZoomSlider = false;
		if (APIManager == null) return;
	    StartCoroutine(APIManager.ZoomSliderOperation((int)((float)ZOOMMAX * zoomSlider.value / (float)99)));
    }

    public void ZoomNear1Pushed() {
	    if (APIManager == null) return;
	    var val = zoomPos - 1;
	    if (val < 0) val = 0;
	    StartCoroutine(APIManager.ZoomSliderOperation(val));
    }

    public void ZoomNear2Pushed() {
	    if (APIManager == null) return;
	    var val = zoomPos - 2;
	    if (val < 0) val = 0;
	    StartCoroutine(APIManager.ZoomSliderOperation(val));
    }

    public void ZoomNear3Pushed() {
	    if (APIManager == null) return;
	    var val = zoomPos - 3;
	    if (val < 0) val = 0;
	    StartCoroutine(APIManager.ZoomSliderOperation(val));
    }

    public void ZoomFar1Pushed() {
	    if (APIManager == null) return;
	    var val = zoomPos + 1;
	    if (val > ZOOMMAX) val = ZOOMMAX;
	    StartCoroutine(APIManager.ZoomSliderOperation(val));
    }

    public void ZoomFar2Pushed() {
	    if (APIManager == null) return;
	    var val = zoomPos + 2;
	    if (val > ZOOMMAX) val = ZOOMMAX;
	    StartCoroutine(APIManager.ZoomSliderOperation(val));
    }

    public void ZoomFar3Pushed() {
	    if (APIManager == null) return;
	    var val = zoomPos + 3;
	    if (val > ZOOMMAX) val = ZOOMMAX;
	    StartCoroutine(APIManager.ZoomSliderOperation(val));
    }

	#endregion

}
