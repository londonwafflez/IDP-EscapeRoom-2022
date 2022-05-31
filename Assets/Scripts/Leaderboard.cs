/*using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;
using static Google.Apis.Sheets.v4.SheetsService;
*//*using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Spreadsheets;*//*

public static class Leaderboard
{
    public static void Initialize() {
        Debug.Log("DataDump Script Started"); //Can be ommitted, should be removed in the final build
        using (var stream = new FileStream("", FileMode.Open, FileAccess.Read)){ //The string is the filepath from the root directory of the c# project, starting in the same folder as the project's .csproj.
            credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        }
        service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer(){
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });
    }
    public static string[] Scopes = {Scope.Spreadsheets}; 
    public static string ApplicationName = "One Way Out"; //Can be anything
    public static string SpreadsheetID = "1ZlVADmM7B8WjgOY-8yd7nzJUorSmVfBua0TbrFYvv5Q"; //Spreadsheet ID, found in the link to the spreadsheet (docs.google.com/spreadsheets/d/ID/edit)
    public static string sheet = "Sheet2"; //The name of the sheet, in the bottom left (Can also be changed to a method argument or string[] instead of hard-coded if using several sheets)
    public static SheetsService service;
    private static GoogleCredential credential;

    /// <summary>
    /// This method reads and returns entries from the spreadsheet as a 2D IList.
    /// </summary>
    public static IList<IList<object>> ReadEntries(string rangeLow, string rangeHigh) { //rangelow and rangehigh are cells like A1 or F12
        var range = $"{sheet}!{rangeLow}:{rangeHigh}"; 
        var request = service.Spreadsheets.Values.Get(SpreadsheetID, range);
        var response = request.Execute();
        var values = response.Values;
        return values;
    }
    /// <summary>
    /// This method creates entries on the spreadsheet (will not overwrite entries).
    /// </summary>
    public static void CreateEntry(string leftColumn, string rightColumn, List<object> inputs) { //leftColumn and rightColumn are the column letters.
        //Method does not check if the input field size is the same as the inputs and it's probably a good idea to add one (can be done by converting to char and using the ascii values or having a list of letters to compare against)
        var range = $"{sheet}!{leftColumn}:{rightColumn}";
        var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();
        valueRange.Values = new List<IList<object>> {inputs} ;
        var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetID, range);
        appendRequest.ValueInputOption = Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        var appendResponse = appendRequest.Execute();
    }
    /// <summary>
    /// This method changes entries on the spreadsheet. (untested)
    /// </summary>
    public static void UpdateEntry(string cell, List<object> inputs) {
        var range = $"{sheet}!{cell}";
        var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();
        valueRange.Values = new List<IList<object>> {inputs};
        var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetID, range);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        var updateResponse = updateRequest.Execute();

    }
    /// <summary>
    /// This method deletes entries from the spreadsheet. (untested)
    /// </summary>
    public static void DeleteEntry(string leftBound, string rightBound) {
        var range = $"{sheet}!{leftBound}:{rightBound}";
        var requestBody = new ClearValuesRequest();
        var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, SpreadsheetID, range);
        var deleteResponse = deleteRequest.Execute();
    }
}
*/