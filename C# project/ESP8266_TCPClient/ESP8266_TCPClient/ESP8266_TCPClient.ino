/*
 Name:		ESP8266_TCPClient.ino
 Created:	7/18/2018 3:36:46 PM
 Author:	Hattory
*/

#include <ESP8266WiFi.h>
#include <string.h>
#include <OneWire.h>
#include <DallasTemperature.h>



#define SerialPort 115200
#define LED_BUILTIN 5
#define TempSens 13
#define Relay_LoadFirst 4


int WiFi_Connect(char* ssid, char* passw, int TryNumb, int Delayms);
int Data_SearchDouble(char* Mess, int Length, char FirstSymb, char SecondSymb);
int Data_SearchOne(char* Mess, int Length, char Symb);
int Action_RunLed(char* Mess, int Length);
void Init_Perephery();
void Relay_OnOFF(int Mode, int Relay);
void LED_OnOFF(int Mode, int LED);
float GetTemperature(DeviceAddress deviceAddress);
float Check_SendTempComm(char* Mess, int Length);
void WiFi_ChangeServIp(char* nIp, int nport);
void WiFi_ChangeData(char* nssid, char* npass);
int Check_ChangeServIp(char* Mess, int Length);

void printTemperature(DeviceAddress deviceAddress);
void Init_TempSensor();

char* ssid = "ASUS";      // SSID
char* password = "13062110";      // Password
char* host = "192.168.0.41";  // IP serveur - Server IP
int   port = 8005;            // Port serveur - Server Port
const int   watchdog = 5000;        // Fr?quence du watchdog - Watchdog frequency
int gChangeSysData = 0;
unsigned long previousMillis = millis();




OneWire oneWire(TempSens);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

void setup()
{
	Init_Perephery();    
	Init_TempSensor();

	Serial.print("Connecting to ");
	Serial.println(ssid);	

	while (WiFi_Connect(ssid, password, 10, 500) != 0)
	{
		Serial.print(".");
		delay(3000);
	}	

	pinMode(13, OUTPUT); 

	//Serial.println("");
	//Serial.println("WiFi connected");
	//Serial.println("IP address: ");
	//Serial.println(WiFi.localIP());
}

void loop()
{

//	sensors.requestTemperatures(); 
//	printTemperature(insideThermometer);
	
	WiFiClient client;
	if (!client.connect(host, port))
	{
		Serial.println("connection failed");
		client.stop();
		return;
	}
	else
	{
		client.println("123321qweq"); //My serial name
		while (client.connected())
		{
			unsigned long timeout = millis();
			
			if (client.available()) //we have data from server
			{
				String line = client.readStringUntil('\n');
				char* pline = new char[line.length()];
				strcpy(pline, line.c_str());				
				
				//Serial.println(pline);

			    if (Data_SearchDouble(pline, line.length(), 'g', 'h'))				
				{				
				//	Serial.println("gh");
					// Control command.
					Action_RunLed(pline, line.length());

					if (Check_SendTempComm(pline, line.length()))
					{
						client.println(GetTemperature(insideThermometer));
						Serial.println(GetTemperature(insideThermometer));						
					}
					client.println("Ctrl"); //we get control message and ready					
				}

	          /*  //System command		
				if (Data_SearchDouble(pline, line.length(), 'h', 'g'))
				{
					// search 'hg14' in input mess
					if (Check_ChangeServIp(pline, line.length()))
					{
						gChangeSysData = 1;
						client.println("SysCH"); //we wait system data
					}
					//Change Ip if  we have gh14 and flag
					if (Data_SearchOne(pline, line.length(), '.') && gChangeSysData)
					{
						Serial.println(pline);
						//WiFi_ChangeServIp(pline);
						gChangeSysData = 0; //Reset flag
						client.println("SysIp");						
					} 
					else if (!Data_SearchOne(pline, line.length(), '.') && gChangeSysData)
					{
						Serial.println(pline);
						//WiFi_ChangeServIp(pline);
						gChangeSysData = 0; //Reset flag
						client.println("SysPort");
					}				
				}		*/
				client.println("q");
			}
				
			}
			
			// Check server connection alive
			unsigned long timeout = millis();
			while (client.available() == 0)  //we lost connection, and try return it
			{
				if (millis() - timeout > watchdog) //if we hanging in client.available() a long time
				{
					Serial.println(">>> Client Timeout !");
					client.stop();
					return;
				}
			}
		}		
		
}

/* Change wifi SSID 
*  Input: nssid - new ssid 
*/
void WiFi_ChangeDataSSID(char* nssid)
{
	ssid = nssid;
}


/* Change wifi Password
*  Input: npass - new  pass
*/
void WiFi_ChangeDataPass(char* npass)
{
	password = npass;
}

/* Change Ip adress data server
*  Input:: nIp - new ip adress
*/
void WiFi_ChangeServ(char* nIp)
{
	host = nIp;	
}


/* Change Port data server
*  Input:: nport - new port
*/
void Wifi_ChangeServPort(int nport)
{
	port = nport;
}

/* Print temperature to Serial Port
*
*
*/
void printTemperature(DeviceAddress deviceAddress)
{
	sensors.requestTemperatures(); 
	float tempC = sensors.getTempC(deviceAddress);
	Serial.print("Temp C: ");
	Serial.print(tempC);
}


/*
* Input: deviceAddress - temp sensor address
* Output: temperature value in float
*/
float GetTemperature(DeviceAddress deviceAddress)
{
	sensors.requestTemperatures();
	float tempC = sensors.getTempC(deviceAddress);
	return tempC;
}


/*  Search two consecutive(i and i+1) symbols in message
*  Input: Mess, FirstSymb, SecondSymb
*		  Length - without '\0' symbol
*  Output: 1 - Found
*          0 - Don't found
*/
int Data_SearchDouble(char* Mess, int Length, char FirstSymb, char SecondSymb)
{
	for (int i = 0; i <= Length + 1; i++)
	{
	//Serial.print(".");
		if (Mess[i] == FirstSymb && Mess[i + 1] == SecondSymb)
		{			
			return 1;			
		}
	}
	return 0;
}


/*  Search one symbol in message
*  Input: Mess, Symb
*		  Length - without '\0' symbol
*  Output: 1 - Found
*          0 - Don't found
*/
int Data_SearchOne(char* Mess, int Length, char Symb)
{
	for (int i = 0; i <= Length + 1; i++)
	{
		//Serial.print(".");
		if (Mess[i] == Symb)
		{
			return 1;
		}
	}
	return 0;
}


/*  Wi-fi connect
*  Input: ssid 
*		  passw
*         TryNumb - how many times we will try connect
*         Delayms - delay between connect try
*  Output: 1 - Connected 
*          0 - Timeout
*/
int WiFi_Connect(char* ssid, char* passw, int TryNumb, int Delayms)
{	
	WiFi.begin(ssid, passw);

	for (int i = 0; i <= TryNumb; i++)
	{
		if (WiFi.status() == WL_CONNECTED) 
		{
			break;
			return 1;
		}
		delay(Delayms);
	}
	return 0;
}


/*  Run Command to change system value, search 'gh14' to change server ip 
*  Input: Mess, nIp
*		  Length - without '\0' symbol
*  Output: 1 - change data
*          0 - error
*/
int Action_ChangeServIp(char* nIp)
{	
		WiFi_ChangeServ(nIp);	
}


/*  Run Command, search 'gh11' to ON led, and 'gh01' to off
*  Input: Mess,
*		  Length - without '\0' symbol
*  Output: 1 - On
*          0 - Off
*		   2 - Error	
*/
int Action_RunLed(char* Mess, int Length)
{
	if (Data_SearchDouble(Mess, Length, '1', '1'))
	{
		LED_OnOFF(1, LED_BUILTIN);
		Serial.println("LED ON");
		return 1;
	}
	else if (Data_SearchDouble(Mess, Length, '0', '1'))
	{
		LED_OnOFF(0, LED_BUILTIN);
		Serial.println("LED OFF");
		return 0;
	}
	else
		return 2;
}

/*  Check Command to send temperature value, search 'gh12' to send temperature value
*  Input: Mess,
*		  Length - without '\0' symbol
*  Output: 1 - allow to get the temperature value
*          0 - don't get
*/
float Check_SendTempComm(char* Mess, int Length)
{
	if (Data_SearchDouble(Mess, Length, '1', '2'))
	{
		return 1;
	}
	else
		return 0;
}


/*  Check Command to change system value, search 'gh14' to change server ip
*  Input: Mess, nIp
*		  Length - without '\0' symbol
*  Output: 1 - change data
*          0 - error
*/
int Check_ChangeServIp(char* Mess, int Length)
{
	if (Data_SearchDouble(Mess, Length, '1', '4'))
	{		
		return 1;
	}
	else
	{
		return 0;
	}
}


/*  Initial perephery 
*
*/
void Init_Perephery()
{
#ifdef LED_BUILTIN
	pinMode(LED_BUILTIN, OUTPUT);
#endif // LED_BUILTIN

#ifdef Relay_LoadFirst
	pinMode(Relay_LoadFirst, OUTPUT);
#endif // Relay_LoadFirst

#ifdef SerialPort 
	Serial.begin(SerialPort);
#endif // SerialPort 

}


/*  Initial temperature sensor
*  Input: Mess,
*		  Length - without '\0' symbol
*/
void Init_TempSensor()
{
	//Begin Sensor
	sensors.begin();
	//Search thermometer
	sensors.getAddress(insideThermometer, 0);
	//Set sensor resolution
	sensors.setResolution(insideThermometer, 9);
}


/*  Controll LED function
*  Input: Mode - 1/0  On/OFf
*		  LED - LED Define Name
*/
void LED_OnOFF(int Mode, int LED)
{
#ifdef LED_BUILTIN 
	if (LED == LED_BUILTIN)
	{
		if (Mode)
			digitalWrite(LED_BUILTIN, HIGH);
		else
			digitalWrite(LED_BUILTIN, LOW);	
	}
#endif // LED_BUILTIN 
}


/*  Controll Relay function
*  Input: Mode - 1/0  On/OFf
*		  Ralay - Realy Define Name
*/
void Relay_OnOFF(int Mode, int Relay)
{
#ifdef Relay_LoadFirst
	if (Relay == Relay_LoadFirst)
	{
		if (Mode)
			digitalWrite(Relay_LoadFirst, HIGH);
		else
			digitalWrite(Relay_LoadFirst, LOW);
	}
#endif // Relay_LoadFirst
}


/*
#define LED_BUILTIN 1
// the setup function runs once when you press reset or power the board
void setup() {
// initialize digital pin LED_BUILTIN as an output.
pinMode(LED_BUILTIN, OUTPUT);
}
digitalWrite(gpio0_pin, HIGH);                            //led 1 ON
// the loop function runs over and over again forever
void loop() {
digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
delay(1000);                       // wait for a second
digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
delay(1000);                       // wait for a second
}
*/
