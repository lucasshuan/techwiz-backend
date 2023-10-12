namespace Techwiz.Errors
{
    public class InvalidFieldError : BaseError
    {
        public InvalidFieldError(string field) : base($"Invalid{field}", "Erro interno do servidor") {}
    }

    public class NotFoundError : BaseError
    {
        public int StatusCode { get; } = 404;
        public NotFoundError(string resource, string translation) : base($"{resource}NotFound", $"{translation} não encontrado") {}
    }

    public class InternalServerError : BaseError
    {
        public InternalServerError() : base("InternalServerError", "Erro interno do servidor") {}
    }

    public class ValidationError : BaseError
    {
        public ValidationError(string field) : base("ValidationError", $"O campo {field} é inválido") {}
    }

    public class DuplicateEntryError : BaseError
    {
        public DuplicateEntryError() : base("DuplicateEntry", "O valor fornecido já existe no sistema") {}
    }
}