from socket import *
import json

serverName = "localhost"
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))
sentence = input().strip()

firstNumberInput = str
secondNumberInput = str

def ChangeFirstAndSecondNumber(fir, sec):
    global firstNumberInput
    global secondNumberInput
    firstNumberInput = fir
    secondNumberInput = sec

request = {
    "RequestType": str,
    "FirstNumber": str,
    "SecondNumber": str
}

def SendAndReceive(clientSocket, requestType, firstNumber, secondNumber):
    request["RequestType"] = requestType
    request["FirstNumber"] = firstNumber
    request["SecondNumber"] = secondNumber
    print(requestType)

    toSend = json.dumps(request) + "\r\n"
    clientSocket.send(toSend.encode())

    response = json.loads(clientSocket.recv(1024).decode())
    for message in response:
        print("From server:",response[message])
    return input()


while True:
    if len(sentence) == 0:
        emptyString = "0"
        sentence = SendAndReceive(clientSocket,emptyString,emptyString,emptyString)
    else:
        if sentence == "Random":
            print("Input numbers")
            randomInput = input().strip()
            randomInputSplit = randomInput.split(" ")

            if len(randomInputSplit) == 2:
                sentence = SendAndReceive(clientSocket,sentence,randomInputSplit[0],randomInputSplit[1])
            else:
                sentence = SendAndReceive(clientSocket,sentence,"0","0")

        elif sentence == "Add":
            print("Input numbers")
            addInput = input().strip()
            addInputSplit = addInput.split(" ")

            if len(addInputSplit) == 2:
                sentence = SendAndReceive(clientSocket,sentence, addInputSplit[0], addInputSplit[1])
            else:
                sentence = SendAndReceive(clientSocket,sentence,"0","0")

        elif sentence == "Subtract":
            print("Input numbers")
            subtractInput = input().strip()
            subtractInputSplit = subtractInput.split(" ")

            if len(subtractInputSplit) == 2:
                sentence = SendAndReceive(clientSocket,sentence, subtractInputSplit[0], subtractInputSplit[1])
            else:
                sentence = SendAndReceive(clientSocket,sentence,"0","0")
            
        else:
            sentence = SendAndReceive(clientSocket,sentence,"0","0")
