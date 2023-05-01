namespace BusinessManagement.Domain.Dtos
{
    public record CreateSellerRequest(string Nome,
                                      string Sobrenome,
                                      string Email,
                                      string Cep,
                                      string Endereco,
                                      string Numero,
                                      string Complemento);

}
