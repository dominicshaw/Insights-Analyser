[![Build status](https://ci.appveyor.com/api/projects/status/github/dominicshaw/insights-analyser?branch=master&amp;svg=true)](https://ci.appveyor.com/project/dominicshaw/insights-analyser/branch/master)

# Insights-Analyser

Working with Xamarin and wanting to understand my custom events I found it hard to visualise what I wanted to visualise in App Center / Insights so I have written a quick UI I find useful.

![Screenshot](https://raw.githubusercontent.com/dominicshaw/Insights-Analyser/master/InsightsAnalyser/screenshot.png)

You can easily:
- group & filter events;
- view a breakout of the "properties" that you set on custom data.

In the screenshot you can see the data grouped by user (this is actually derived from the custom properties; I add "user" to all trace events), then by session, to differentiate between each "run" of the application. 

You can further see I am limiting the return to certain kinds of custom event name to show just the ones I am interested in. 

On the right the breakout of the JSON blobs that come back; first the "Properties" blob which is always the same, and then below is the breakout of the data dictionary you append to the custom events via the app center tracking methods.

## How to use

### Step 1 - add app center to your app
- follow instructions @ appcenter.ms.

### Step 2 - add an export from app centre to insights
- click your app in app center; 
- click settings;
- click export -> add new -> insights;
- create export.

### Step 3 - export from insights
- once it has exported and set up, you will have a "View in Azure" button on the export; click it;
- this opens azure, now click "Analytics" in the menu near the top;
- double click "customEvents" on the left; this pulls up a query;
- run the query for any time period you like;
- hit the export button - csv, all columns.

### Step 4 - load the file
- run the app;
- click the browse button and find your csv;
- the file will load and you can interrogate the data.

Any suggestions please let me know. It would be nice to work with other event types but I am using Xamarin and most of them have no meaning for me.

