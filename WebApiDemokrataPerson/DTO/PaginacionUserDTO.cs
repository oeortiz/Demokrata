namespace WebApiDemokrataPerson.DTO
{
    public class PaginacionUserDTO
    {   
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 3;
        private readonly int cantidadMaximaPorPagina = 10;

        public int RecordsPorPagina
        {
            get { return recordsPorPagina; }
            set
            {
                recordsPorPagina = (value > cantidadMaximaPorPagina) ? cantidadMaximaPorPagina : value;
                //previene que el usuario solicite cantidades incoherentes de registros por pág.
                //ya que nuestro ejemplo tien unicamente 6 registros inicialmente
            }
        }
    }
}