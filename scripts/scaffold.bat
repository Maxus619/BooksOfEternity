dotnet ef dbcontext scaffold^
    --project "..\BooksOfEternity\BooksOfEternity.csproj"^
    --context BookDbContext^
    --context-dir "..\BooksOfEternity\DataAccess"^
    --output-dir "..\BooksOfEternity\DataAccess\Entities"^
    --force^
    --table book.users^
    --table book.users_info^
    --table book.books^
    --table book.book_records^
    --table book.likes^
    "Server=localhost;Port=5432;Database=book;Username=book_user;Password=qzwxec123;Timeout=1024;"^
    Npgsql.EntityFrameworkCore.PostgreSQL