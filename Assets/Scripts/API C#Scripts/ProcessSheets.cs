using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProcessSheets : MonoBehaviour
{
    private int progress = 0;
    string[,] leaderboardData = new string[5,2];
    public TMP_Text userText;
    public TMP_Text scoreText;

    void Start() {
        Load();
    }
 
    public void Load() {
        StartCoroutine( DownloadSheets.DownloadData( AfterDownload ) );
    }
 
    public void AfterDownload( string data ) {
        if ( null == data ) {
            Debug.LogError( "Was not able to download data or retrieve stale data." );
            // TODO: Display a notification that this is likely due to poor internet connectivity
            //       Maybe ask them about if they want to report a bug over this, though if there's no internet I guess they can't
        }
        else {
            StartCoroutine( ProcessData( data, AfterProcessData ) );
        }
    }
 
    private void AfterProcessData( string errorMessage ) {
        if ( null != errorMessage ) {
            Debug.LogError( "Was not able to process data: " + errorMessage );
        }
        else {
            string username = "";
            string score = "";

            for (int i = 0; i < 5; i++) {
                username = username + "\n\n" + leaderboardData[i, 0];
                score = score + "\n\n" + leaderboardData[i, 1];
                // Debug.Log(username + "\n\n" + score);
                // Debug.Log(leaderboardData[i, 0] + "\n\n" + leaderboardData[i, 1]);
            }
            userText.text = username;
            scoreText.text = score;

            Debug.Log("Data displayed");
        }
    }
 
    public IEnumerator ProcessData( string data, System.Action<string> onCompleted ) {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
 
        // Line level
        int currLineIndex = 0;
        bool inQuote = false;
        int linesSinceUpdate = 0;
        int kLinesBetweenUpdate = 15;
 
        // Entry level
        string currEntry = "";
        int currCharIndex = 0;
        bool currEntryContainedQuote = false;
        List<string> currLineEntries = new List<string>();
 
        // "\r\n" means end of line and should be only occurence of '\r' (unless on macOS/iOS in which case lines ends with just \n)
        char lineEnding = '\r'; //\n for ios
        int lineEndingLength = 2; // 1 for ios
 
        while ( currCharIndex < data.Length ) {
            if ( !inQuote && ( data [ currCharIndex ] == lineEnding ) ) {
                // Skip the line ending
                currCharIndex += lineEndingLength;
 
                // Wrap up the last entry
                // If we were in a quote, trim bordering quotation marks
                if ( currEntryContainedQuote ) {
                    currEntry = currEntry.Substring( 1, currEntry.Length-2 );
                }
 
                currLineEntries.Add( currEntry );
                currEntry = "";
                currEntryContainedQuote = false;
 
                // Line ended
                ProcessLineFromCSV( currLineEntries, currLineIndex );
                currLineIndex++;
                currLineEntries = new List<string>();
 
                if (currLineIndex > 5) {
                    Debug.Log("Max index reached");
                    break;
                }

                linesSinceUpdate++;
                if ( linesSinceUpdate > kLinesBetweenUpdate ) {
                    linesSinceUpdate = 0;
                    yield return new WaitForEndOfFrame();
                }
            }
            else {
                if ( data [ currCharIndex ] == '"' ) {
                    inQuote = !inQuote;
                    currEntryContainedQuote = true;
                }
 
                // Entry level stuff
                {
                    if ( data [ currCharIndex ] == ',' ) {
                        if ( inQuote ) {
                            currEntry += data [ currCharIndex ];
                        }
                        else {
                            // If we were in a quote, trim bordering quotation marks
                            if ( currEntryContainedQuote ) {
                                currEntry = currEntry.Substring( 1, currEntry.Length-2 );
                            }
 
                            currLineEntries.Add( currEntry );
                            currEntry = "";
                            currEntryContainedQuote = false;
                        }
                    }
                    else {
                        currEntry += data [ currCharIndex ];
                    }
                }
                currCharIndex++;
            }
 
            progress = ( int ) ( ( float ) currCharIndex / data.Length  * 100.0f );

            if (progress % 25 == 0) Debug.Log(progress);
        }
 
        onCompleted( null );
    }
 
    private void ProcessLineFromCSV( List<string> currLineElements, int currLineIndex ) {
 
        // This line contains the column headers, telling us which languages are in which column
        if ( currLineIndex == 0 ) {
            //do nothing
        }
        // This is a normal node
        else if ( currLineElements.Count > 1 ) {
            for ( int columnIndex = 0; columnIndex < currLineElements.Count; columnIndex++ ) {
                try {leaderboardData[currLineIndex - 1, columnIndex] = currLineElements [ columnIndex ];}
                catch (System.IndexOutOfRangeException e) {Debug.LogError(string.Format("Error: " + e + "\nTried to enter leaderboardData[{0}, {1}]", (currLineIndex - 1), columnIndex));}
            }
        }
        else {
            Debug.LogError( "Database line did not fall into one of the expected categories." );
        }
    }
}
