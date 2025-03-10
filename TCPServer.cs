using System.Net.Sockets;

namespace JSONTCP{
    public class TCPServer{
        public static void HandleClient(TcpClient socket, int port){
            bool isRunning = true;
            Random random = new();

            using(socket){
                NetworkStream ns = socket.GetStream();

                StreamReader reader = new(ns);
                StreamWriter writer = new(ns);
                writer.AutoFlush = true;

                while(isRunning){
                    string? incomingRequest = reader.ReadLine();

                    if(incomingRequest != null){
                        Request? request = JSONUtil.Deserialize(incomingRequest);
                        string? responseMessage = null;

                        if(request != null){
                            bool isFirstNumberValid = int.TryParse(request.FirstNumber,out int first);
                            bool isSecondNumberValid = int.TryParse(request.SecondNumber,out int second);

                            if(isFirstNumberValid){
                                if(isSecondNumberValid){
                                    switch(request.RequestType){
                                        default:
                                            responseMessage = request.RequestType;
                                            break;
                                        case "Random":
                                            if(first < second){
                                                responseMessage = random.Next(first,second +1).ToString();
                                            }
                                            else{
                                                responseMessage = "First number must be lower than the second number";
                                            }
                                            break;
                                        case "Add":
                                            responseMessage = $"{first + second}";
                                            break;
                                        case "Subtract":
                                            responseMessage = $"{first - second}";
                                            break;
                                    }
                                }
                                else{
                                    responseMessage = "Second number must be a number";
                                }
                            }
                            else{
                                responseMessage = "First number must be a number";
                            }
                        }
                        else{
                            responseMessage = "Bad request";
                        }
                        if(responseMessage == null){
                            throw new ArgumentNullException("Response is null");
                        }
                        Response response = new(responseMessage);
                        writer.Write(JSONUtil.Serialize(response));
                    }
                }
            }
        }
    }
}
