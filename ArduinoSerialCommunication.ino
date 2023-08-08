const int ledPin = 8;  // Pin number to which the LED is connected
const int E = 1;       // Explanation of the purpose of this variable (e.g., why it's named "E")

String receivedChar;   // Variable to hold received serial data

void setup() {
  pinMode(ledPin, OUTPUT); // Set the LED pin as an output
  Serial.begin(9600);      // Start serial communication (at 9600 baud rate)
}

void loop() {
  receiveData(); // Call the receiveData() function to process incoming data
}

void handleEvent() {
  // Check if the received data is "OPEN"
  if (receivedChar == "OPEN") {
    digitalWrite(ledPin, HIGH);  // Turn the LED on (HIGH)
    Serial.println("Led is open"); // Send status message over the serial port
  } else {
    digitalWrite(ledPin, LOW);   // Turn the LED off (LOW)
    Serial.println("Led is closed"); // Send status message over the serial port
  }
}

void receiveData() {
  while (Serial.available() > 0) { // If there's data available on the serial port
    receivedChar = Serial.readStringUntil('\n'); // Read the incoming data until a newline character
    handleEvent(); // Call the handleEvent() function to process the incoming data
  }
}
