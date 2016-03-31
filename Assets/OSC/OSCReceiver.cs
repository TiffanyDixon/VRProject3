
using UnityEngine;
using System.Collections;

public class OSCReceiver : MonoBehaviour {

	//You can set these variables in the scene because they are public 
	public string RemoteIP = "127.0f.0.1f";
	public int SendToPort = 57131;
	public int ListenerPort = 57130;
	public Transform controller; 
	private Osc handler;
	float[] messages = {0.0f,0.0f,0.0f,0.0f,1.0f,1.0f};
	//static Array stringMessages = ["","","","","",""];

	//private Osc osc;

	public void  Start (){
		//Initializes on start up to listen for messages
		//make sure this game object has both UDPPackIO and OSC script attached

		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(RemoteIP, SendToPort, ListenerPort);
		handler = GetComponent<Osc>();
		handler.init(udp);

		handler.SetAddressHandler("/VDMX/1", ListenEvent);
		handler.SetAddressHandler("/VDMX/2", ListenEvent);
		handler.SetAddressHandler("/VDMX/3", ListenEvent);
		handler.SetAddressHandler("/VDMX/4", ListenEvent);
		handler.SetAddressHandler("/VDMX/5", ListenEvent);

	}

	public void ListenEvent ( OscMessage oscMessage  ){	
		int i = 0;
		switch(oscMessage.Address){
			case "/VDMX/1":	i = 0; break;
			case "/VDMX/2":	i = 1; break;
			case "/VDMX/3":	i = 2; break;
			case "/VDMX/4":	i = 3; break;
			case "/VDMX/5":	i = 4; break;

		}

		//Debug.Log (oscMessage.Values [0].ToString ());
		messages[i] = float.Parse(oscMessage.Values[0].ToString());
		//stringMessages[i] = messages[i];

	} 

	public float getMessage(int i){
		return messages [i];
	}

}