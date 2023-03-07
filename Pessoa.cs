namespace ExercicioAPI1
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }

        public Pessoa(int id, string nome, string cidade)
        {
            Validations = new List<string>();

            Id = id;
            Nome = nome;
            Cidade = cidade;

            this.Validar();
        }

        public List<string> Validations { get; }
        public bool IsValid { get; set; }

        private void Validar()
        {
            if(this.Id <= 0)
            {
                Validations.Add("O Id não pode ser igual a zero ou negativo");
            }
            if(string.IsNullOrEmpty(this.Nome) )
            {
                Validations.Add("O nome não pode ser vazio");
            }
            if(string.IsNullOrEmpty(this.Cidade) )
            {
                Validations.Add("A cidade não pode ser vazia");
            }

            this.IsValid = !Validations.Any();
        }
    }
}
