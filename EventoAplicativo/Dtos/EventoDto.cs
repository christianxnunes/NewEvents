using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventoAplicativo.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Intervalo permitido de 4 a 50 caracteres.")]
        public string Tema { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Local { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string DataEvento { get; set; }
        [Display(Name = "Qtd Pessoas")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(1, 120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120000")]
        public int QtdPessoas { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemURL { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Phone(ErrorMessage="{0} está com número inválido")]
        public string Telefone { get; set; }
        [Display(Name = "e-mail")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "E necessario ser um {0} válido")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}