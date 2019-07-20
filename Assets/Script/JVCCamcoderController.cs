using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JVCCamcoder;
using UnityEngine.UI;

public class JVCCamcoderController : MonoBehaviour {

	[SerializeField] private JVCCamcoderStatus CamcoderStatus;
	[SerializeField] private JVCCamcoderAPIManager APIManager;
	[SerializeField] private Slider slider;
	[SerializeField] private Text zoomPositionText;
	[SerializeField] private Text zoomSpeedText;
	[SerializeField] private Text IrisValueText;
	[SerializeField] private Text IrisModeText;

	private int oldZoomValue = Int32.MinValue;
	private int oldSliderValue = Int32.MinValue;
	private string oldIrisMode = "";
	private string oldIrisValue = "";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (CamcoderStatus == null) return;
		Dictionary<string, dynamic> zoomDict = CamcoderStatus.ZoomDictionary;
		if (zoomDict != null) {
			int zoomPosition = ((int)zoomDict["Position"]);
			if (oldZoomValue != zoomPosition) {
				zoomPositionText.text = $"Zoom:{zoomPosition}";
				oldZoomValue = zoomPosition;
			}
		}

		Dictionary<string, dynamic> irisDict = CamcoderStatus.IrisDictionary;
		if (irisDict != null) {
			string irisMode = ((string) irisDict["Status"]);
			string irisValue = ((string) irisDict["Value"]);
			if (oldIrisMode != irisMode) {
				IrisModeText.text = irisMode;
				irisMode = oldIrisMode;
			}

			if (oldIrisValue != irisValue) {
				IrisValueText.text = irisValue;
				oldIrisValue = irisValue;
			}
		}

		if (oldSliderValue != (int)slider.value) {
			zoomSpeedText.text = $"{(int) slider.value}";
			int val = (int)slider.value;
			if (val == 0) {
				StartCoroutine(APIManager.ZoomSwitchOperation("Stop", val));
			}
			else if (val < 0) {
				StartCoroutine(APIManager.ZoomSwitchOperation("Wide", -val));
			}
			else {
				StartCoroutine(APIManager.ZoomSwitchOperation("Tele", val));
			}
			oldSliderValue = (int)slider.value;
		}
	}

	public void onMouseUpZoomSlider() {
		Debug.Log("------------------------------mouseup---------------------------------");
		slider.value = 0;
	}
}
