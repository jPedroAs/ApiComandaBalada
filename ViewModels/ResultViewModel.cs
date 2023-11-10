namespace ApiBalada.ViewModels;

 public class ResultViewModel<T>
    {
        public ResultViewModel( T data, List<string>erro)
        {
            this.Data = data;
            this.Error = erro;
        }

        public ResultViewModel(T data)
        {
            this.Data = data;
        }

        public ResultViewModel(string erro)
        {
            Error.Add(erro);
        }
        public T Data { get; private set; }
        public List<string> Error { get; set; } = new();
    }