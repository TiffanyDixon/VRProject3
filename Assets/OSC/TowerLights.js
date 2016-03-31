#pragma strict

var duration : float = 1.0;
var color0 : Color = Color.red;
var color1 : Color = Color.blue;
var intensity : int = 8.0;
var lt: Light;

var oscChannel: int;

function Start () {
	lt = GetComponent.<Light>();

}


function Update () {
	// set light color
	var t : float = Mathf.PingPong(Time.time, duration) / duration;
	lt.color = Color.Lerp(color0, color1, t);

	//var n = OSCReceiver.messages[oscChannel];
	//var n: float;
	//var k : float = 8.0f;

	var n =OSCReceiver.messages[oscChannel];

	//var x = String(OSCReceiver.messages[oscChannel]);

	//Vector3 V3 = Vector3(n,n,n);
	var k = 8;

	//var i = n * k;

	//String rekt = OSCReceiver.stringMessages[oscChannel];


	/*
	var str = '';
    for (var p in n) {
        if (obj.hasOwnProperty(p)) {
            str += p + '::' + obj[p] + '\n';
        }
    }
	*/
	//intensity=  intensity * OSCReceiver.messages[oscChannel];
	//int n = parseInt(String(OSCReceiver.messages[oscChannel]));
	//var string = Convert.ToString(n);
	//var n = parseInt(JSON.stringify(n));
	//var x = String(n);
	//var intN = parseInt(String(n));
	//var intN = parseInt(rekt);
	//var kN = intN * 8.0f;
	//transform.localScale = Vector3(n,n,n);
	//lt.intensity = intN*8.0f;

}