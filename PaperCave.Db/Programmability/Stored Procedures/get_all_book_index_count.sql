CREATE PROCEDURE get_all_book_index_count
	@Count SMALLINT,
	@Index SMALLINT
AS
BEGIN
	SELECT 
		Id, 
		Title, 
		AuthorId, 
		PageCount, 
		GenreId, 
		CreatedTs, 
		UpdatedTs 
	FROM 
		book_tbl
	ORDER BY Id
	OFFSET @Index ROWS
	FETCH NEXT @Count ROWS ONLY;
END
GO
