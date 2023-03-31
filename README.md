# Doggy Diary


This is a simple console application for tracking your dog's pee and poo activities. The program allows you to add entries to a log file for each time your dog goes pee or poo, and view those entries through various filters.

## How to Use

When you run the program, you will be presented with a menu of options:

1. Make a Potty Entry
2. View Today's Entries
3. View Entrie's by Dog
4. View Or Delete All Previous Entries
5. Exit

### Making a Potty Entry
To add an entry for a dog's pee or poo activity, select option 1 from the menu. You will be prompted to select which dog you are making an entry for and the type of activity (pee or poo). The entry will be saved with a timestamp to a log file for future reference.

### Viewing Today's Entries
To view entries for the current date, select option 2 from the menu. The program will display a list of all entries for the current date.

### Viewing Entries for a Specifc Dog
To view entries for a specific dog, select option 3 from the menu. You will be prompted to select the dog from a list, and the program will then display all entries for that dog.

### Viewing & Deleting All Previous Entries
To view all entries ever made for all dogs and dates, select option 4 from the menu. You will be presented with the full list of entry records, and prompted if you would like to delete all entries. This cannot be undone and you must confirm this action.

### Exiting the Program
To exit the program, select option 5 from the menu. All entries will be saved to the log file before the program exits.

## Feature List:

1. Master Loop - Implemented in the Main Menu
2. Additional Class that Inherits from a Parent Class - Created an Entry class for PeePooEntry to inherit from
3. Read Data from External File - List of Dogs & Pee/Poo Entries are Read/Saved to Separate .txt Files
4. Usa LINQ Query - Used to View Entries by Dog & View Entries for Today's Date
