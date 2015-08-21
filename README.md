# BMap.NET
a library for operating baidu maps,encapsulating Web Service API 
with C# language,also contains a list of controls which can be used in
winform.

see more here(chinese blog): [my cnblogs][0]

---
## overview
the source code contains 3 projects: `BMap.NET`,`BMap.NET.WindowsForm` and 
`BMap.NET.WinformDemo`.
- BMap.NET

	encapsulates web service api, which return JObject(json.net) object.
- BMap.NET.WindowsForm

	contains some controls which can be used in winform.for example:
	`BMapControl` which can display baidu map, `BDirectionBoard` is responsible
	for navigation, etc.
	
- BMap.NET.WinformDemo

	a demo showing how to use controls in BMap.NET.WindowsForm.
	
some screenshots below:

1. autocomplete search box

	![][2]
2. POIs search

	![][3]
3. direction

	![][4]	
4. add markers and drawing

	![][5]
5. search in bounds

	![][6]
6. select city

	![][7] 

## can do and cant do
can do in **BMap.NET**:
- Search places by city, bounds, circle(nearby);
- Place suggestion;
- Geocoding;
- Direction(transit, driving, walking);
- Located by IP;
- Coordinates transofrm;

can do in **BMap.NET.WindowsForm**:
- Display Baidu Map(drag, move, zoom etc);
- Select map mode(normal, satellite, roadnet);
- Set map load mode(cache, cache_first, server);
- Drawing shapes in map;
- Measturing distance;
- Add Markers in map;
- Save map to image (screenshot by selectting a region);
- Autocomplete search box;
- Direction control;
- Places list control;

cant do:

- ~~3D map~~;
- ~~Street view~~;
- ~~Direction according to real-time traffic conditions~~;

In addition, this project is used only for Baidu map, so the `Extension ability`
is so so. you can modify the source code to meet your needs.

## how to use
`BMap.NET` is very simple to use(just some interfaces to get json data 
from baidu map server). 

`BMap.NET.WindowsForm` only opens 5 controls: `BPlaceBox`, `BMapControl`, 
`BPlacesBoard`, `BDirectionBoard` and the `BTabControl`. you can drag them into
form desinger and set few properties to let them build associations like this:

1. BPlaceBox

	![][8]
2. BPlacesBoard

	![][9]
3. BMapControl

	![][10]
4. BDirectionBoard

	![][11]

**press F5 without any other writed codes.**

`BTabControl` is only used as a container which contains `BPlacesBoard` and 
`BDirectionBoard`.

## thanks
my thanks below:

1. baidu map api documents(http://developer.baidu.com/map/index.php?title=webapi)
2. json.net(https://json.codeplex.com/)
3. json visualization(http://www.bejson.com/)


**all source code follow the [MIT][1] license.**

[0]: http://www.cnblogs.com/xiaozhi_5638/
[1]: https://zh.wikipedia.org/wiki/MIT%E8%A8%B1%E5%8F%AF%E8%AD%89
[2]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/B3.png
[3]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/B1.jpg
[4]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/B2.jpg
[5]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/B4.jpg
[6]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/B5.jpg
[7]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/B6.jpg
[8]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/b14.png
[9]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/b12.png
[10]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/b13.png
[11]: https://github.com/sherlockchou86/BMap.NET/blob/master/Asserts/b15.png