using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using static Guestbook;

public class Guestbook : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameInput;

    [SerializeField]
    private GameObject entryPrefab;

    [SerializeField]
    private GameObject guestbookEntryContainer;

    private string saveDirectory = Path.Combine(Application.dataPath, "Outputs/guestbook.json");

    [Serializable]
    public class GuestbookEntry
    {
        public int id;
        public string name;
        public GuestbookEntry(string name, int id)
        {
            this.id = id;
            this.name = name;
        }
    }

    private void Start()
    {
        ShowGuests();
    }

    public void SaveEntry()
    {
        //get existing guests (if any)
        GuestbookEntry[] currentGuests = GetGuests();

        //add guest in existing guests
        string name = nameInput.text;
        if (String.IsNullOrEmpty(name))
        {
            return;
        }

        int id = GetGuests().Length + 1;

        GuestbookEntry guestbookEntry = new GuestbookEntry(name, id);
        currentGuests = currentGuests.Append(guestbookEntry).ToArray();

        //json string conversion
        string json = JsonHelper.ToJson(currentGuests, true);

        //write in file
        File.WriteAllText(saveDirectory, json);
        ShowGuests();
    }

    public void ShowGuests()
    {
        // Clear existing entries in the container
        foreach (Transform child in guestbookEntryContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Get all guests
        GuestbookEntry[] guests = GetGuests();

        foreach (GuestbookEntry entry in guests)
        {
            CreateGuestUI(entry);
        }
    }
    private void CreateGuestUI(GuestbookEntry guestEntry)
    {
        // Instantiate the prefab
        GameObject newEntry = Instantiate(entryPrefab, guestbookEntryContainer.transform);

        // Find TMP_Text components
        TMP_Text[] textComponents = newEntry.GetComponentsInChildren<TMP_Text>();

        foreach (TMP_Text textComponent in textComponents)
        {
            if (textComponent.name == "Id")
            {
                textComponent.text = guestEntry.id.ToString();
            }
            else if (textComponent.name == "Name")
            {
                textComponent.text = guestEntry.name;
            }
        }
    }

    private GuestbookEntry[] GetGuests()
    {
        // Check if the file exists
        if (!File.Exists(saveDirectory))
        {
            return new GuestbookEntry[0];
        }

        // Read the JSON from the file
        string json = File.ReadAllText(saveDirectory);

        // Deserialize the JSON to a list of objects
        GuestbookEntry[] guestList = JsonHelper.FromJson<GuestbookEntry>(json);

        GuestbookEntry[] result;
        if (guestList != null)
        {
            result = guestList;
        }
        else
        {
            result = new GuestbookEntry[0];
        }

        return result;
    }
}
