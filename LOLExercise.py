import requests
import json

ApiURL = "https://restexerciseleagueoflegends20251117174906-gvgua7byayfngeff.swedencentral-01.azurewebsites.net/api/champions"


# HENT HELE LISTEN
def get_all_posts():
    response = requests.get(ApiURL)
    if response.status_code == 200:
        data = response.json()
        print("Alle objekter:")
        for item in data:               
            print(item)
    else:
        print("Fejl ved GET:", response.status_code)


# HENT ET ENKELT OBJEKT
def get_single_post(post_id):
    response = requests.get(f"{ApiURL}/{post_id}")
    if response.status_code == 200:
        print("Enkelt objekt:")
        print(response.json())
    else:
        print("Fejl ved GET:", response.status_code)


# OPRET ET OBJEKT
def create_post():
    new_post = {
        "name": "test",
        "role": "Support",
        "description": "test description",
        "difficulty": "hard",
        "releaseDate": "2020-05-11T00:00:00Z"
    }

    response = requests.post(ApiURL, json=new_post)
    print("Oprettet objekt:")
    print(response.json())



# OPDATER ET OBJEKT
def update_post(post_id):
    updated_post = {
        "name": "test updated",
        "role": "Support",
        "description": "test description",
        "difficulty": "hard",
        "releaseDate": "2020-05-11T00:00:00Z"
    }

    response = requests.put(f"{ApiURL}/{post_id}", json=updated_post)
    print("Opdateret objekt:")
    print(response.json())



# SLET ET OBJEKT
def delete_post(post_id):
    response = requests.delete(f"{ApiURL}/{post_id}")
    print("Slet svar-kode:", response.status_code)


# MAIN PROGRAM
def main():
    print("\n--- HENTER ALLE OBJEKTER ---")
    get_all_posts()

    print("\n--- HENTER ÉT OBJEKT ---")
    get_single_post(1)

    print("\n--- OPRETTER OBJEKT ---")
    create_post()

    print("\n--- OPDATERER OBJEKT ---")
    update_post(4)

    print("\n--- SLETTER OBJEKT ---")
    delete_post(4)


if __name__ == "__main__":
    main()
