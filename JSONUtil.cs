using System.Text.Json;

namespace JSONTCP{
    public class JSONUtil{
        public static Request? Deserialize(string jsonString){
            return JsonSerializer.Deserialize<Request>(jsonString);
        }

        public static string? Serialize(Response? response){
            return JsonSerializer.Serialize(response);
        }
    }
}
