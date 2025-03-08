namespace JSONTCP{
    public class Request{
        private string? requestType;
        private string? firstNumber;
        private string? secondNumber;

        public Request(string? requestType, string? firstNumber, string? secondNumber){
            RequestType = requestType;
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public string? RequestType{
            get => requestType;
            set{
                requestType = value;
            }
        }

        public string? FirstNumber{
            get => firstNumber;
            set{
                firstNumber = value;
            }
        }

        public string? SecondNumber{
            get => secondNumber;
            set{
                secondNumber = value;
            }
        }
    }
}
