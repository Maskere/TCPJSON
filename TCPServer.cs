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

                        if(request != null){
                            if(int.TryParse(request.FirstNumber,out int first)){
                                if(int.TryParse(request.SecondNumber,out int second)){
                                    if(request.RequestType == "Random"){
                                        if(first < second){
                                            writer.Write(random.Next(first, second + 1));
                                        }
                                        else{
                                            writer.Write("First number must be lower than second");
                                        }
                                    }
                                    else if(request.RequestType == "Add"){
                                        writer.Write(first + second);
                                    }
                                    else if(request.RequestType == "Subtract"){
                                        writer.Write(first - second);
                                    }
                                    else{
                                        writer.Write(request.RequestType);
                                    }
                                }
                                else{
                                    writer.Write("Invalid input: Second number must be a number");
                                }
                            }
                            else{
                                writer.Write("Invalid input: First number must be a number");
                            }
                        }
                        else{
                            writer.Write("Bad request");
                        }
                    }
                    else{
                    }
                }
            }
        }
    }
}
