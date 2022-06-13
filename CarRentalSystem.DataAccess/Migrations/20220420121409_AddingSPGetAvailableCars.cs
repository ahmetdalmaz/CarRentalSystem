using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.DataAccess.Migrations
{
    public partial class AddingSPGetAvailableCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
			 @"CREATE PROCEDURE [dbo].[uspAvailableCars]
			@RentalDate datetime = null,
			@ReturnDate datetime = null,
			@Color varchar(50) = null,
			@FuelType varchar(50) = null,
			@Plate varchar(8) = null,
			@ModelName varchar(60) = null,
			@SegmentName varchar(1) = null
			AS 
			BEGIN

				DECLARE @SQL VARCHAR(MAX)
				DECLARE @ColorFilter VARCHAR(MAX)
				DECLARE @FuelTypeFilter VARCHAR(MAX)
				DECLARE @PlateFilter VARCHAR(MAX)
				DECLARE @ModelNameFilter VARCHAR(MAX)
				DECLARE @SegmentNameFilter VARCHAR(MAX)
				DECLARE @All VARCHAR(2) = '-1'
	

				SET @ColorFilter = CASE WHEN @Color IS NULL OR @Color = ''
				THEN ''''+@All +''' = '''+@All+ ''''
				ELSE 'Color = '''+@Color +''' '
				END

				SET @FuelTypeFilter = CASE WHEN @FuelType IS NULL OR @FuelType = ''
				THEN ''''+@All +''' = '''+@All+ ''''
				ELSE 'FuelType = '''+@FuelType +''' '
				END

				SET @PlateFilter = CASE WHEN @Plate IS NULL OR @Plate = ''
				THEN ''''+@All +''' = '''+@All+ ''''
				ELSE 'Plate = '''+@Plate +''' '
				END

				SET @ModelNameFilter = CASE WHEN @ModelName IS NULL OR @ModelName = ''
				THEN ''''+@All +''' = '''+@All+ ''''
				ELSE 'ModelName = '''+@ModelName +''' '
				END

				SET @SegmentNameFilter = CASE WHEN @SegmentName IS NULL OR @SegmentName = ''
				THEN ''''+@All +''' = '''+@All+ ''''
				ELSE 'SegmentName = '''+@SegmentName +''' '
				END

				SET @SQL = 'select CarId,Plate,BrandName,ModelName,Color, SegmentName,Kilometre,FuelType from Cars,Models tblm,Brands tblb,Segments tbls
				where CarId not in
				(select CarId from Rentals where 
				(Rentals.State = ''r'' or Rentals.State = ''k'') and '''+CONVERT(VARCHAR,@RentalDate,23)+'''< RentalDate and '''+CONVERT(VARCHAR,@ReturnDate,23)+'''>RentalDate and '''+CONVERT(VARCHAR,@ReturnDate,23)+'''<= ReturnDate
				OR '''+CONVERT(VARCHAR,@RentalDate,23)+'''<= RentalDate and '''+CONVERT(VARCHAR,@ReturnDate,23)+'''> ReturnDate and (Rentals.State = ''r'' or Rentals.State = ''k'')
				OR '''+CONVERT(VARCHAR,@RentalDate,23)+'''< ReturnDate and '''+CONVERT(VARCHAR,@RentalDate,23)+'''>= RentalDate and (Rentals.State = ''r'' or Rentals.State = ''k'') ) 
				AND Cars.ModelId = tblm.ModelId and Cars.SegmentId = tbls.SegmentId AND tblm.BrandId = tblb.BrandId
				AND '+@ColorFilter+'AND '+@FuelTypeFilter+'AND '+@PlateFilter+'AND '+@ModelNameFilter+'AND '+@SegmentNameFilter+''
	
	
				EXEC(@SQL)
			END");
			

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"drop procedure uspAvailableCars");
        }
    }
}
