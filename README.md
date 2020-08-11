# RbrPro-Addons
First of all, what the hell is RBRPro? <b>Discover it here <a href="https://www.rbrpro.org">https://www.rbrpro.org</a></b><br><br>
Want to develop an addon for the RBRPro manager? Welcome to the right place!

Since version <b>0.3.0.0</b> the RBRPro Manager supports Add-Ons. An NGP6 Telemetry server has been implemented. An add-on can become a Telemetry client and receive telemetry data from the manager.

In other words the RBRProManager behaves in a way which is very similar to SimHub. It receives the NGP telemetry via UDP and provides the data to its add-ons.
An add-on in basically a WPF Control hosted in the Add-Ons tab of the manager.

A working example is provided.
It is a complete Add-On with the following features:

1. Uses the TGD Localization engine to translate its GUI according to the language selected in the manager
2. Uses the Lightweight TGD MVVM framework for data binding and configuration persistence
3. Receives the telemetry and visualizes the car speed
4. Starts the game from a command Button

Some ideas for a new addon? Here are some hints...

- Hosting a new championship with its own calendar and rankings
- Implementing a driver for a dynamic simulator
- Implementing a co-driver engine (yes... TGD Navigator will be an addon...)
- A custom on-screen overlay
- A new online plugin...

How to start
---------------------------
To compile the solution you will need to reference the <b>TGD.Common.dll</b> contained in your RBRPro installation root directory. Both the RBRPro.API and the TestAddon project makes use of its packages.

About
---------------------------
<b>TGD Localization Engine</b>

This is the small framework I wrote to allow the language switch in RBRPro, and you know how well it works...
After evaluating other frameworks I've come to the conclusion that they didn't have the features I was looking for.
My localization engine is really simple to use. It make use of the "Tag" and "ToolTip" properties.
The language file is a simple .ini file. The <b>Load()</b> method of the <b>Localizer</b> class loads the iniFile into a C# Dictionary.
when you set Tag="SectionName. PropertyName" the engine retrievies the property "PropertyName" in the section "SectionName" of its current language.
Once loaded the dictionary, the <b>Localizer</b>'s <b>Translate()</b> method translates by a recursive traversal of the whole WPF LogicalTree, starting from the element you provide as the root (usually the main window or control). For convenience, I  use a static class as a "proxy" for the Localizer, so that i can recall it from whatever point in the code.

<b>TGD ContextManager</b>

This class is simple and sophisticated at the same time. It provides a convenient way to implement your viewModel because both the [RuntimeProperties] and the [ConfigProperties] are "Observable". The class allow the use of multiple configuration files as well. [ConfigProperties] are automatically loaded and saved. You can use only simple C# types but this is not a big limitation. The [RuntimeProperties] are the volatile ones, there is no limitation in the type, they can be also Collection.
Together with the ObservableCollection class provided by the TGD.Framework package these classes are a good starting point to develop WPF based applications.

Licensing
---------------------------
You are free to download and use this code for any non-commercial purposes. For any other purpose please contact info.rbrpro@gmail.com
