from socket import *
import json

serverName = "localhost"
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))
sentence = input().strip()

request = {
    "RequestType": str,
    "FirstNumber": str,
    "SecondNumber": str
}

def SendAndReceive(clientSocket, requestType, firstNumber, secondNumber):
    request["RequestType"] = requestType
    request["FirstNumber"] = firstNumber
    request["SecondNumber"] = secondNumber

    toJson = json.dumps(request)
    toSend = toJson + "\r\n"
    clientSocket.send(toSend.encode())
    response = clientSocket.recv(1024)
    print("From server:",response.decode())
    return input()


while True:
    if len(sentence) == 0:
        emptyString = "0"
        sentence = SendAndReceive(clientSocket,emptyString,emptyString,emptyString)

    elif sentence == "Random":
        print("Input numbers")
        randomInput = input().strip()
        randomInputSplit = randomInput.split(" ")
        sentence = SendAndReceive(clientSocket,sentence,randomInputSplit[0],randomInputSplit[1])

    elif sentence == "Add":
        print("Input numbers")
        addInput = input().strip()
        addInputSplit = addInput.split(" ")
        sentence = SendAndReceive(clientSocket,sentence, addInputSplit[0], addInputSplit[1])

    else:
        sentenceToSend = sentence
        sentence = SendAndReceive(clientSocket, sentenceToSend,"0","0")
