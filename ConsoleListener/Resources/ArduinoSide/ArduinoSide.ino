/**
   JoystickShield - Arduino Library for JoystickShield (http://hardwarefun.com/projects/joystick-shield)

   Copyright 2011  Sudar Muthu  (email : sudar@sudarmuthu.com)

 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * <sudar@sudarmuthu.com> wrote this file. As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer or coffee in return - Sudar
 * ----------------------------------------------------------------------------
 * 2014 edit by Markus Mücke, muecke.ma(a)gmail.com
 * Changes for JoysikShield V1.2
 * added a function to read the amplitude of the joystick
 * added a auto calibrate function for 3.3V and 5V mode
 *
 * Added functions:
 *  Functions for F and E Button
 *  Calibrate Joystick
 *  xAmplitude
 *  yAmplitude
 */

/**
 * Before running this example, stack the JoystickShield on top of Arduino board
 *
 */
#include <JoystickShield.h> // include JoystickShield Library
#include <stdbool.h>

JoystickShield joystickShield; // create an instance of JoystickShield object
bool leftPress = false;
bool rightPress = false;
bool jumpPress = false;
int xAmp = 0;

const int pin_right_button = 3; //Change in case right button changes

void setup() {
    Serial.begin(9600);
    
    delay(100);
    // new calibration function
    joystickShield.calibrateJoystick();
}


void loop() {
	xAmp = joystickShield.xAmplitude();
    joystickShield.processEvents(); // you don't have do anything else
	if(joystickShield.isRightButton() && !jumpPress)
	{
		jumpPress = true;
		Serial.println("Wd");
	}
	else if(jumpPress && (digitalRead(pin_right_button) == HIGH))
	{
		jumpPress = false;
		Serial.println("Wu");
	}
	
	if(!rightPress && (xAmp > 50))
	{
		rightPress = true;
		Serial.println("Dd");
	}
	else if(!leftPress && (xAmp < -50))
	{
		leftPress = true;
		Serial.println("Ad");
	}
	
	if(rightPress && (xAmp < 50))
	{
		rightPress = false;
		Serial.println("Du");
	}
	else if(leftPress && (xAmp > -50))
	{
		leftPress = false;
		Serial.println("Au");
	}
	
    delay(10);	//10ms response resolution
}
