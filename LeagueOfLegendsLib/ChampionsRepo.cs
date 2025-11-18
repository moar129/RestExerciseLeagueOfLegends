using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueOfLegendsLib
{
    public class ChampionsRepo
    {
        private int _nextId = 1;
        private List<Champion> _champions;
        public ChampionsRepo()
        {
            _champions = new List<Champion>();
            _champions.Add(new Champion
            {
                Id = _nextId++,
                Name = "Aatrox",
                Role = "Top",
                Description = "Once honored defenders of Shurima against the Void, Aatrox and his brethren would eventually become an even greater threat to Runeterra.",
                Difficulty = "hard",
                ReleaseDate = new DateTime(2013, 6, 13)
            });
            _champions.Add(new Champion
            {
                Id = _nextId++,
                Name = "Ahri",
                Role = "Mid",
                Description = "A cunning fox who can manipulate magic and emotions, Ahri is a vastaya who draws power from the life essence of others.",
                Difficulty = "medium",
                ReleaseDate = new DateTime(2011, 12, 14)
            });
            _champions.Add(new Champion
            {
                Id = _nextId++,
                Name = "Akali",
                Role = "Mid",
                Description = "Once a member of the Kinkou Order, Akali now walks a solitary path, striking swiftly and silently to eliminate those who threaten Ionia.",
                Difficulty = "hard",
                ReleaseDate = new DateTime(2010, 5, 11)
            });
        }
        public IEnumerable<Champion> Get(string? nameIncludes = null , string? descriptionIncludes = null, string? orderBy = null)
        {
            IEnumerable<Champion> result = new List<Champion>(_champions);
            // Filter
            if (nameIncludes != null)
            {
                result = result.Where(c => c.Name.Contains(nameIncludes));
            }
            if (descriptionIncludes != null)
            {
                result = result.Where(c => c.Description.Contains(descriptionIncludes));
            }
            // Sort
            if (!string.IsNullOrEmpty(orderBy))
            {
                result = orderBy.ToLower() switch
                {
                    "name" or "name_asc" => result.OrderBy(c => c.Name),
                    "name_desc" => result.OrderByDescending(c => c.Name),

                    "role" or "role_asc" => result.OrderBy(c => c.Role),
                    "role_desc" => result.OrderByDescending(c => c.Role),

                    "releasedate" or "releasedate_asc" => result.OrderBy(c => c.ReleaseDate),
                    "releasedate_desc" => result.OrderByDescending(c => c.ReleaseDate),

                    _ => result
                };
            }
            return result;
        }
        public Champion? GetById(int id)
        {
            return _champions.FirstOrDefault(c => c.Id == id);
        }
        public Champion Add(Champion champion)
        {
            champion.Id = _nextId++;
            _champions.Add(champion);
            return champion;
        }
        public Champion? Update(int id, Champion updatedChampion)
        {
            Champion? existingChampion = GetById(id);
            if (existingChampion != null)
            {
                existingChampion.Name = updatedChampion.Name;
                existingChampion.Role = updatedChampion.Role;
                existingChampion.Description = updatedChampion.Description;
                existingChampion.Difficulty = updatedChampion.Difficulty;
            }
            return existingChampion;
        }
        public Champion Delete(int id)
        {
            Champion? championToDelete = GetById(id);
            if (championToDelete != null)
            {
                _champions.Remove(championToDelete);
            }
            return championToDelete;
        }
    }
}
