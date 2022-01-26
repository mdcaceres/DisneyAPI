create database DisneyAPIDb 
go
use DisneyAPIDb
set dateformat dmy 

create table Genders(
    idGender int identity(1,1) not null, 
    gender varchar(max), 
    imgUrl varchar(max),
    constraint pk_gender primary key (idGender)
)

create table Characters (
    idCharacter int identity(1,1) not null, 
    name varchar(max), 
    age int, 
    weight decimal, 
    story varchar(max), 
    imgUrl varchar(max)
    constraint pk_Character primary key (idCharacter)
)

create table Movies(
    idMovie int identity(1,1) not null, 
    Title varchar(max), 
    ReleaseD datetime, 
    rating int check (rating BETWEEN 1 and 5),
    imgUrl varchar(max),
    constraint pk_Movie primary key (idMovie),
 )

create table MovieCharacters(
    idMovie int,
    idCharacter int
    constraint pk_MovieDetails primary key (idCharacter,idMovie)
    constraint fk_Character FOREIGN key (idCharacter) references Characters(idCharacter),
    constraint fk_Movie foreign key (idMovie) references Movies(idMovie)
)

create table MovieGenders(
    idMovie int,
    idGender int
    constraint pk_MovieGenders primary key (idGender,idMovie)
    constraint fk_Gender FOREIGN key (idGender) references Genders(idGender),
    constraint fk_MovieGender foreign key (idMovie) references Movies(idMovie)
)

-----------------------INSERTS--------------------------------
insert into Genders Values ('Animated film','https://Disneyimages.com/gender') 
insert into Genders Values ('Short film','https://Disneyimages.com/gender')
insert into Genders Values ('Comedy','https://Disneyimages.com/gender')
insert into Genders Values ('Romance','https://Disneyimages.com/gender')
insert into Genders Values ('Action','https://Disneyimages.com/gender')
insert into Genders Values ('Sci-fi','https://Disneyimages.com/gender')
insert into Genders Values ('Fantasy','https://Disneyimages.com/gender')


Insert into Characters values ('Mickey Mouse',65,50.15,'A mouse who typically wears red shorts, large yellow shoes, and white gloves, Mickey is one of the worlds most recognizable fictional characters.','https://Disneyimages.com/mickey')
insert into Characters values ('Minnie Mouse',60,30.15,' As the longtime sweetheart of Mickey Mouse, she is a mouse with white gloves, a bow, polka-dotted dress, and low-heeled shoes occasionally with ribbons on them','https://Disneyimages.com/minnie')
Insert into Characters values ('Pluto',91,60.15,'Pluto is Mickey Mouses pet dog that first appeared as a nameless bloodhound in 1930 s The Chain Gang. ','https://Disneyimages.com/pluto')
Insert into Characters values ('Goofy',89,99.15,'He is a tall dog who typically wears a turtle neck and vest, with pants, shoes, white gloves, and a tall hat originally designed as a rumpled fedora. Goofy is a close friend of Mickey Mouse and Donald Duck.','https://Disneyimages.com/goofy')
Insert into Characters values ('Donald Duck',90,65.10,'He typically wears a sailor shirt and cap with a bow tie. Donald is known for his semi-intelligible speech and his mischievous, temperamental, and pompous personality.','https://Disneyimages.com/donald')
Insert into Characters values ('Daisy Duck',84,75.10,'As the girlfriend of Donald Duck, she is a white duck that has large eyelashes and ruffled tail feathers around her lowest region to suggest a skirt. She is often seen wearing a hair bow, blouse, and heeled shoes.','https://Disneyimages.com/daisy')

Insert into Characters values ('Obi-wan Kenobi',30,65.00,'A legendary Jedi Master, Obi-Wan Kenobi was a noble man and gifted in the ways of the Force. He trained Anakin Skywalker, served as a general in the Republic Army during the Clone Wars, and guided Luke Skywalker as a mentor.','https://Disneyimages.com/obi-wan')
insert into Characters values ('Anakin Skywalker',20,62.00,'Discovered as a slave on Tatooine by Qui-Gon Jinn and Obi-Wan Kenobi, Anakin Skywalker had the potential to become one of the most powerful Jedi ever, and was believed by some to be the prophesied Chosen One who would bring balance to the Force. A hero of the Clone Wars, Anakin was caring and compassionate, but also had a fear of loss that would prove to be his downfall.','https://Disneyimages.com/annakin')
Insert into Characters values ('Luke Skywalker',20,60.15,'Luke Skywalker was a Tatooine farmboy who rose from humble beginnings to become one of the greatest Jedi the galaxy has ever known. Along with his friends Princess Leia and Han Solo, Luke battled the evil Empire, discovered the truth of his parentage, and ended the tyranny of the Sith. A generation later, the location of the famed Jedi master was one of the galaxy’s greatest mysteries. Haunted by Ben Solo’s fall to evil and convinced the Jedi had to end, Luke sought exile on a distant world, ignoring the galaxy’s pleas for help. But his solitude would be interrupted – and Luke Skywalker had one final, momentous role to play in the struggle between good and evil.','https://Disneyimages.com/luke')
Insert into Characters values ('Leia Organa',20,58.15,'Princess Leia Organa was one of the greatest leaders of the Rebel Alliance, fearless on the battlefield and dedicated to ending the Empire’s tyranny. Daughter of Padmé Amidala and Anakin Skywalker, sister of Luke Skywalker, and with a soft spot for scoundrels, Leia ranked among the galaxy’s great heroes. But life under the New Republic proved difficult for her. Sidelined by a new generation of political leaders, she struck out on her own to oppose the First Order as founder of the Resistance. These setbacks in her political career were accompanied by more personal losses, which she endured with her seemingly inexhaustible will. ','https://Disneyimages.com/leia')
Insert into Characters values ('Boba Fetf',30,65.10,'With his customized Mandalorian armor, deadly weaponry, and silent demeanor, Boba Fett was one of the most feared bounty hunters in the galaxy. A genetic clone of his “father,” bounty hunter Jango Fett, Boba learned combat and martial skills from a young age. Over the course of his career, which included contracts for the Empire and the criminal underworld, he became a legend.','https://Disneyimages.com/bobafett')
Insert into Characters values ('Darth Vader',35,100.10,'Once a heroic Jedi Knight, Darth Vader was seduced by the dark side of the Force, became a Sith Lord, and led the Empire’s eradication of the Jedi Order. He remained in service of the Emperor -- the evil Darth Sidious -- for decades, enforcing his Master’s will and seeking to crush the fledgling Rebel Alliance. But there was still good in him…','https://Disneyimages.com/darthvader')


select * from Characters

insert into Movies values ('The Karnival Kid','23/05/1929',4,'https://Disneyimages.com/TheKarnivalKid')
insert into Movies values ('Plane Crazy','15/05/1928',5,'https://Disneyimages.com/PlaneCrazy')
insert into Movies values ('The Chain Gang','18/09/1930',3,'https://Disneyimages.com/TheChainGang')
insert into Movies values ('Mickeys Revue','25/05/1932',4,'https://Disneyimages.com/MickeysRevue')
insert into Movies values ('The wise little hen','03/05/1934',5,'https://Disneyimages.com/Thewiselittlehen')
insert into Movies values ('Mr. Duck Steps Out','07/06/1940',3,'https://Disneyimages.com/Thewiselittlehen')
insert into Movies values ('The three Musketeers','17/08/2004',3,'https://Disneyimages.com/ThethreeMusketeers')

insert into Movies values ('Star Wars: The clone wars','15/08/2008',4,'https://Disneyimages.com/Star Wars:Theclonewars') 
insert into Movies values ('Star Wars: the Phantom Menace','19/05/1999',5,'https://Disneyimages.com/Star Wars:thePhantomMenace') 
insert into Movies values ('Star Wars: Return of the jedi','25/05/1983',5,'https://Disneyimages.com/returnofthejedi') 
insert into Movies values ('Star Wars: New hope','12/08/1976',3,'https://Disneyimages.com/starwarsnewhope') 

select * from Movies

insert into MovieGenders values (1,1)
insert into MovieGenders values (1,2)
insert into MovieGenders values (1,3)
insert into MovieGenders values (1,7)

insert into MovieGenders values (2,1)
insert into MovieGenders values (2,3)
insert into MovieGenders values (2,4)
insert into MovieGenders values (2,7)

insert into MovieGenders values (3,1)
insert into MovieGenders values (3,2)
insert into MovieGenders values (3,3)
insert into MovieGenders values (3,7)

insert into MovieGenders values (4,1)
insert into MovieGenders values (4,3)
insert into MovieGenders values (4,7)

insert into MovieGenders values (5,1)
insert into MovieGenders values (5,2)
insert into MovieGenders values (5,3)
insert into MovieGenders values (5,7)

insert into MovieGenders values (6,1)
insert into MovieGenders values (6,3)
insert into MovieGenders values (6,4)
insert into MovieGenders values (6,7)

insert into MovieGenders values (7,1)
insert into MovieGenders values (7,3)
insert into MovieGenders values (7,7)

insert into MovieGenders values (8,5)
insert into MovieGenders values (8,6)
insert into MovieGenders values (8,7)

insert into MovieGenders values (9,5)
insert into MovieGenders values (9,6)
insert into MovieGenders values (9,7)

insert into MovieGenders values (10,5)
insert into MovieGenders values (10,6)
insert into MovieGenders values (10,7)

insert into MovieGenders values (11,5)
insert into MovieGenders values (11,6)
insert into MovieGenders values (11,7)

select * from movies

insert into MovieCharacters values (1,1)

insert into MovieCharacters values (2,1)
insert into MovieCharacters values (2,2)

insert into MovieCharacters values (3,1)
insert into MovieCharacters values (3,3)

insert into MovieCharacters values (4,1)
insert into MovieCharacters values (4,2)
insert into MovieCharacters values (4,4)

insert into MovieCharacters values (5,5)

insert into MovieCharacters values (6,5)
insert into MovieCharacters values (6,6)

insert into MovieCharacters values (7,1)
insert into MovieCharacters values (7,2)
insert into MovieCharacters values (7,3)
insert into MovieCharacters values (7,4)
insert into MovieCharacters values (7,5)
insert into MovieCharacters values (7,6)

insert into MovieCharacters values (8,7)
insert into MovieCharacters values (8,8)

insert into MovieCharacters values (9,7)
insert into MovieCharacters values (9,8)

insert into MovieCharacters values (10,9)
insert into MovieCharacters values (10,10)
insert into MovieCharacters values (10,11)
insert into MovieCharacters values (10,12)

insert into MovieCharacters values (11,7)
insert into MovieCharacters values (11,9)
insert into MovieCharacters values (11,10)
insert into MovieCharacters values (11,11)
insert into MovieCharacters values (11,12)

--------------------------------------------------------------
---Charcters SP-----
GO
create proc SP_GetCharacters
as
select * from Characters 

GO
create proc SP_CharactersByMovie
@idMovie int = null
as
select c.idCharacter, c.name,c.age,c.weight,c.story,c.imgUrl from Characters c join MovieCharacters mc on c.idCharacter = mc.idCharacter 
where mc.idMovie = @idMovie

go 
create proc SP_FilterCharacter
@name varchar(50) = null,
@age int = null,
@weight decimal = null,
@idMovie int = null
AS
if @name is null and @age is not null and @weight is null
select * from Characters where age = @age
if @name is not null and @age is null and @weight is null
select * from Characters where name Like '%'+@name+'%'
if @weight is not null and @age is null and @name is null
select * from Characters where weight = @weight
if @idMovie is not null and @age is null and @name is null and @weight is null 
select c.idCharacter, c.name,c.age, c.weight,c.story,c.imgUrl from Characters c join MovieCharacters mc on mc.idCharacter = c.idCharacter
where mc.idMovie = @idMovie
else select * from Characters where name Like '%'+@name+'%' and age = @age

go
create proc sp_createCharacter
@name varchar(50),
@age int,
@weight decimal,
@story varchar(max), 
@imgUrl varchar(max)
AS
Insert into Characters values (@name,@age,@weight,@story,@imgUrl);

go
create proc sp_UpdateCharacter 
@id int,
@name varchar(50),
@age int,
@weight decimal,
@story varchar(max), 
@imgUrl varchar(max)
as 
update characters set name = @name, age = @age, weight = @weight, story = @story, imgUrl = @imgUrl
where idCharacter = @id

GO
create proc sp_DeleteCharacter
@id int
as 
delete from MovieCharacters where idCharacter = @id
delete from characters where idCharacter = @id

---------------------
------Movies SP-----
go
create proc SP_GetMovies
AS
select m.idMovie,m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m

GO
create proc SP_MoviesByCharacter
@id int = null
as
select m.idMovie,m.Title,m.ReleaseD,m.rating,m.imgUrl from MovieCharacters mc join movies m on mc.idMovie = m.idMovie
where mc.idCharacter = @id

go 
create proc SP_FilterMovies
@id int = null,
@title varchar(50) = null,
@gender int = null,
@order varchar(5) = null
AS
if @title is null and @id is not null and @gender is null
select m.idMovie, m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m
where m.idMovie = @id 
if @title is null and @id is null and @gender is not null
select m.idMovie,m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m
join MovieGenders mg on mg.idMovie = m.idMovie 
where mg.idGender = @gender
if @title is not null and @gender is null and @id is null
select m.idMovie,m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m where m.Title Like '%'+@title+'%'
if @order='ASC'
select m.idMovie,m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m
order by m.title ASC
if  @order='DESC'
select m.idMovie,m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m
order by m.Title DESC
else select m.idMovie,m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m
join MovieGenders mg on mg.idMovie = m.idMovie 
where m.title Like '%'+@title+'%' and mg.idGender=@gender


go 
Create proc SP_MovieById
@id int = null
AS
select m.Title,m.ReleaseD,m.rating,m.imgUrl from movies m
where m.idMovie = @id 

go
create proc sp_createMovie
@idMovie int output, 
@title varchar(50),
@date datetime,
@rating int,
@url varchar(max)
as
insert into Movies values (@title,@date,@rating,@url)
set @idMovie = SCOPE_IDENTITY();

go 
create proc sp_UpdateMovie
@idMovie int, 
@title varchar(50),
@date datetime,
@rating int,
@url varchar(max)
as 
update movies set title = @title, ReleaseD = @date, rating = @rating , imgUrl = @url
where idMovie = @idMovie

go 
create proc sp_DeleteMovie
@id int
as 
delete from MovieGenders where idMovie = @id
delete from MovieCharacters where idMovie = @id
delete from movies where idMovie = @id

------MovieCharacters--------
go
create proc sp_addCharactersToMovie
@idMovie int,
@idCharacter int
as 
insert into MovieCharacters values (@idMovie,@idCharacter)

------MovieGenders--------
go
create proc sp_addMovieGenders
@idMovie int,
@idGender int
as 
insert into MovieGenders values (@idMovie,@idGender)

go
create proc SP_getMovieGenders
@idMovie int 
as 
select g.idGender, g.gender from Genders g join MovieGenders mg on mg.idGender = g.idGender
where mg.idMovie = @idMovie

---------------------------------------------------------------------
