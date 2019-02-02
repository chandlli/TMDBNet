using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TMDBNet.Implementations;
using TMDBNet.Model.Search;
using Xunit;
using Shouldly;
using System.Linq;

namespace TMDBNet.Tests.Search
{
    public sealed class AllPropertiesTest
    {
        private readonly SearchResultDTO allMovieProperties;
        private readonly SearchResultDTO allTvShowProperties;
        private readonly SearchResultDTO allPeopleProperties;
        private readonly SearchResultDTO allMultiSearchProperties;

        public AllPropertiesTest()
        {
            allMovieProperties = new SearchResultDTO()
            {
                Page = 1,
                Results = new SearchResultItemDTO[]
                {
                    new SearchResultItemDTO()
                    {
                        PosterPath = "/cezWGskPY5x7GaglTTRN4Fugfb8.jpg",
                        IsAdult = true,
                        Overview = "When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!",
                        ReleaseDate = "2012-04-25",
                        GenresId = new int[]
                        {
                            878, 28, 12
                        },
                        Id = 24428,
                        OriginalTitle = "The Avengers",
                        OriginalLanguage = "en",
                        Title = "The Avengers",
                        BackdropPath = "/hbn46fQaRmlpBuUrEiFqv0GDL6Y.jpg",
                        Popularity = 7.353212m,
                        VoteCount = 8503,
                        Video = true,
                        VoteAverage = 7.33m
                    },
                    new SearchResultItemDTO()
                    {
                        PosterPath = "/7cJGRajXMU2aYdTbElIl6FtzOl2.jpg",
                        IsAdult = true,
                        Overview = "British Ministry agent John Steed, under direction from \"Mother\", investigates a diabolical plot by arch-villain Sir August de Wynter to rule the world with his weather control machine. Steed investigates the beautiful Doctor Mrs. Emma Peel, the only suspect, but simultaneously falls for her and joins forces with her to combat Sir August.",
                        ReleaseDate = "1998-08-13",
                        GenresId = new int[]
                        {
                            53
                        },
                        Id = 9320,
                        OriginalTitle = "The Avengers",
                        OriginalLanguage = "en",
                        Title = "The Avengers",
                        BackdropPath = "/8YW4rwWQgC2JRlBcpStMNUko13k.jpg",
                        Popularity = 2.270454m,
                        VoteCount = 111,
                        Video = true,
                        VoteAverage = 4.7m
                    }
                },
                TotalResults = 2,
                TotalPages = 1
            };

            allTvShowProperties = new SearchResultDTO()
            {
                Page = 1,
                Results = new SearchResultItemDTO[]
                {
                    new SearchResultItemDTO()
                    {
                        PosterPath = "/jIhL6mlT7AblhbHJgEoiBIOUVl1.jpg",
                        Popularity = 29.780826m,
                        Id = 1399,
                        BackdropPath = "/mUkuc2wyV9dHLG0D0Loaw5pO2s8.jpg",
                        VoteAverage = 7.91m,
                        Overview = "Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and icy horrors beyond.",
                        FirstAirDate = "2011-04-17",
                        OriginalCountry = new string[]
                        {
                            new string("US")
                        },
                        GenresId = new int[]
                        {
                            10765, 10759, 18
                        },
                        OriginalLanguage = "en",
                        VoteCount = 1172,
                        Name = "Game of Thrones",
                        OriginalName = "Game of Thrones"
                    }
                },
                TotalResults = 1,
                TotalPages = 1
            };

            allPeopleProperties = new SearchResultDTO()
            {
                Page = 1,
                Results = new SearchResultItemDTO[]
                {
                    new SearchResultItemDTO()
                    {
                        ProfilePath = "/2daC5DeXqwkFND0xxutbnSVKN6c.jpg",
                        IsAdult = false,
                        Id = 51329,
                        KnownFor = new SearchResultItemDTO[]
                        {
                            new SearchResultItemDTO()
                            {
                                PosterPath = "/y31QB9kn3XSudA15tV7UWQ9XLuW.jpg",
                                IsAdult = false,
                                Overview = "Light years from Earth, 26 years after being abducted, Peter Quill finds himself the prime target of a manhunt after discovering an orb wanted by Ronan the Accuser.",
                                ReleaseDate = "2014-07-30",
                                OriginalTitle = "Guardians of the Galaxy",
                                GenresId = new int[]
                                {
                                    28,878,12
                                },
                                Id = 118340,
                                MediaType = Model.MediaType.Movie,
                                OriginalLanguage = "en",
                                Title = "Guardians of the Galaxy",
                                BackdropPath = "/bHarw8xrmQeqf3t8HpuMY7zoK4x.jpg",
                                Popularity = 9.267731m,
                                VoteCount = 5002,
                                Video = false,
                                VoteAverage = 7.97m
                            },
                            new SearchResultItemDTO()
                            {
                                PosterPath = "/xn3QM6aInhQp631K2lXpGFox2Kc.jpg",
                                Popularity = 6.605526m,
                                Id = 60866,
                                Overview = "A medical student who becomes a zombie joins a Coroner's Office in order to gain access to the brains she must reluctantly eat so that she can maintain her humanity. But every brain she eats, she also inherits their memories and must now solve their deaths with help from the Medical examiner and a police detective.",
                                BackdropPath = "/d2YDPTQPe3mI2LqBWwb0CchN54f.jpg",
                                VoteAverage = 6.01m,
                                MediaType = Model.MediaType.Tv,
                                FirstAirDate = "2015-03-17",
                                OriginalCountry = new string[]
                                {
                                     "US"
                                },
                                GenresId = new int[]
                                {
                                    27,18,80,10765
                                },
                                OriginalLanguage = "en",
                                VoteCount = 69,
                                Name = "iZombie",
                                OriginalName = "iZombie"
                            }
                        },
                        Name = "Bradley Hemmings",
                        Popularity = 1.273m
                    }
                },
                TotalResults = 1,
                TotalPages = 1
            };

            allMultiSearchProperties = new SearchResultDTO()
            {
                Page = 1,
                TotalPages = 1,
                TotalResults = 3,
                Results = new SearchResultItemDTO[]
                {
                    new SearchResultItemDTO()
                    {
                        PosterPath = "/dl4ftVOH532YmV1I9jOLYwexv2F.jpg",
                        Popularity = 1,
                        Id = 19532,
                        Overview = "The Mrs Bradley Mysteries is a 1998-99 British drama series starring Diana Rigg as Adela Bradley, and Neil Dudgeon as her chauffeur George Moody. The series was produced by the BBC for its BBC One channel, based on the character created by detective writer Gladys Mitchell. Five episodes were produced, including a pilot special. Graham Dalby provided the theme music You're the Cream in My Coffee and he appeared with his orchestra in two episodes. Stylish images of the 1920s are featured, including a classic Rolls Royce limousine and art deco fashions and jewellery worn by the title character.\n\nThe series was shown in the United States by PBS broadcaster WGBH as part of its Mystery! anthology strand, and introduced by Diana Rigg. The full series was also aired in Australia in 2011 by the Seven Network's station 7Two.",
                        BackdropPath = "/lHebXNadF0WDJWTxO4Zud3xM8he.jpg",
                        VoteAverage = 0,
                        MediaType = Model.MediaType.Tv,
                        FirstAirDate = "10-10-2012",
                        OriginalCountry = new string[]
                        {
                            "en"
                        },
                        GenresId = new int[]
                        {
                            18
                        },
                        OriginalLanguage = "en",
                        VoteCount = 2,
                        Name = "The Mrs Bradley Mysteries",
                        OriginalName =  "The Mrs Bradley Mysteries"
                    },
                    new SearchResultItemDTO()
                    {
                        PosterPath = "/jksXcyWURdXMcGgShL0aMSR7g8d.jpg",
                        IsAdult = false,
                        Overview  ="Bradley vs. Provodnikov for the WBO Welterweight title was fought on March 16th, 2012 at The Home Depot Center in Carson, California, USA.",
                        ReleaseDate = "2013-03-16",
                        OriginalTitle = "Bradley vs. Provodnikov",
                        GenresId = new int[]
                        {
                            1
                        },
                        Id = 179821,
                        MediaType = Model.MediaType.Movie,
                        OriginalLanguage = "en",
                        Title = "Bradley vs. Provodnikov",
                        BackdropPath = "/jzqQCuTQyZAglGMTV8fSE3HKpma.jpg",
                        Popularity = 1.001714m,
                        VoteCount = 1,
                        Video = true,
                        VoteAverage = 2
                    },
                    new SearchResultItemDTO()
                    {
                        ProfilePath = "/2daC5DeXqwkFND0xxutbnSVKN6c.jpg",
                        IsAdult = false,
                        Id = 51329,
                        MediaType = Model.MediaType.People,
                        KnownFor = new SearchResultItemDTO[]
                        {
                            new SearchResultItemDTO()
                            {
                                PosterPath =  "/y31QB9kn3XSudA15tV7UWQ9XLuW.jpg",
                                IsAdult = false,
                                Overview = "Light years from Earth, 26 years after being abducted, Peter Quill finds himself the prime target of a manhunt after discovering an orb wanted by Ronan the Accuser.",
                                ReleaseDate = "2014-07-30",
                                OriginalTitle = "Guardians of the Galaxy",
                                GenresId = new int[] {
                                    28,878,12
                                },
                                Id = 118340,
                                MediaType = Model.MediaType.Movie,
                                OriginalLanguage =  "en",
                                Title =  "Guardians of the Galaxy",
                                BackdropPath = "/bHarw8xrmQeqf3t8HpuMY7zoK4x.jpg",
                                Popularity = 9.267731m,
                                VoteCount = 5002,
                                Video = false,
                                VoteAverage = 7.97m
                            },
                            new SearchResultItemDTO()
                            {
                                PosterPath = "/dl4ftVOH532YmV1I9jOLYwexv2F.jpg",
                                Popularity = 1,
                                Id = 19532,
                                Overview = "The Mrs Bradley Mysteries is a 1998-99 British drama series starring Diana Rigg as Adela Bradley, and Neil Dudgeon as her chauffeur George Moody. The series was produced by the BBC for its BBC One channel, based on the character created by detective writer Gladys Mitchell. Five episodes were produced, including a pilot special. Graham Dalby provided the theme music You're the Cream in My Coffee and he appeared with his orchestra in two episodes. Stylish images of the 1920s are featured, including a classic Rolls Royce limousine and art deco fashions and jewellery worn by the title character.\n\nThe series was shown in the United States by PBS broadcaster WGBH as part of its Mystery! anthology strand, and introduced by Diana Rigg. The full series was also aired in Australia in 2011 by the Seven Network's station 7Two.",
                                BackdropPath = "/lHebXNadF0WDJWTxO4Zud3xM8he.jpg",
                                VoteAverage = 0,
                                MediaType = Model.MediaType.Tv,
                                FirstAirDate = "10-10-2012",
                                OriginalCountry = new string[]
                                {
                                    "en"
                                },
                                GenresId = new int[]
                                {
                                    18
                                },
                                OriginalLanguage = "en",
                                VoteCount = 2,
                                Name = "The Mrs Bradley Mysteries",
                                OriginalName =  "The Mrs Bradley Mysteries"
                            }
                        },
                        Name = "David Bradley",
                        Popularity = 2.62283m
                    }
                }
            };
        }

        [Fact]
        public async Task Movies()
        {
            var handlerMock = HttpMockFactory.CreateMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(allMovieProperties))
            });

            var httpConnection = new HttpConnection(handlerMock.Object);

            var search = new TMDBNet.Implementations.Search("", httpConnection);

            var result = await search.MovieAsync("avengers");

            result.ShouldNotBeNull();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(allMovieProperties.Results.Length);

            for (var index = 0; index < result.Results.Count; index++)
            {
                var movie = result.Results[index];
                var expectedMovie = SearchResultFactory.CreateMovie(
                    allMovieProperties.Results[index]);

                movie.ShouldBe(expectedMovie);
            }
        }

        [Fact]
        public async Task TvShow()
        {
            var handlerMock = HttpMockFactory.CreateMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(allTvShowProperties))
            });

            var httpConnection = new HttpConnection(handlerMock.Object);

            var search = new TMDBNet.Implementations.Search("", httpConnection);

            var result = await search.TvShowAsync("Game of thrones");

            result.ShouldNotBeNull();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(allTvShowProperties.Results.Length);

            for (var index = 0; index < result.Results.Count; index++)
            {
                var tvShow = result.Results[index];
                var expectedTvShow = SearchResultFactory.CreateTvShow(
                    allTvShowProperties.Results[index]);

                tvShow.ShouldBe(expectedTvShow);
            }
        }

        [Fact]
        public async Task People()
        {
            var handlerMock = HttpMockFactory.CreateMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(allPeopleProperties))
            });

            var httpConnection = new HttpConnection(handlerMock.Object);

            var search = new TMDBNet.Implementations.Search("", httpConnection);

            var result = await search.PeopleAsync("Bradley");

            result.ShouldNotBeNull();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(allPeopleProperties.Results.Length);

            for (var index = 0; index < result.Results.Count; index++)
            {
                var people = result.Results[index];
                var expectedPeople = SearchResultFactory.CreatePeople(allPeopleProperties.Results[index]);

                people.ShouldBe(expectedPeople);
            }
        }

        [Fact]
        public async Task MultiSearch()
        {
            var handlerMock = HttpMockFactory.CreateMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(allMultiSearchProperties))
            });

            var httpConnection = new HttpConnection(handlerMock.Object);

            var search = new TMDBNet.Implementations.Search("", httpConnection);

            var result = await search.MultiSearchAsync("Bradley");

            result.ShouldNotBeNull();
            result.Results.ShouldNotBeNull();

            var expected = SearchResultFactory.CreateMultiSearch(allMultiSearchProperties);
            var actual = result.Results;

            actual.ShouldBe(expected);
        }
    }
}
