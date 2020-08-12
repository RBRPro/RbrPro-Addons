# RbrPro-Addons
First of all, what the hell is RBRPro? <b>Discover it here <a href="https://www.rbrpro.org">https://www.rbrpro.org</a></b><br><br>
Want to develop an addon for the RBRPro manager? Welcome to the right place!

Since version <b>0.3.0.0</b> the RBRPro Manager supports Add-Ons. An NGP6 Telemetry server has been implemented and the support for Add-ons has been added. An add-on can behave as a client and receive telemetric data from the manager.

In other words, the RBRPro Manager behaves in a way which is very similar to SimHub (do you know it?). It receives the NGP telemetry from the game via UDP protocol and provides the data to its add-ons.
An add-on is basically a WPF Control hosted in the Add-Ons tab of the manager.

A working example is provided.
It is a complete Add-On with the following features:

- Uses the TGD Localization engine to translate its GUI according to the language selected in the manager
- Uses the Lightweight TGD MVVM framework for data binding and configuration persistence
- Receives the telemetry and visualizes the car speed in real time
- Starts the game from a command Button

Some ideas for a new addon? Here are some hints...

- Hosting a new championship with its own calendar and rankings
- Implementing a driver for a dynamic simulator
- Implementing a co-driver engine (yes... TGD Navigator will be an addon...)
- A custom on-screen overlay
- A new online plugin...

How to start
---------------------------
To compile the solution you will need to reference the <b>TGD.Common.dll</b> and the <b>RBRPro.API.dll</b> contained in your RBRPro installation root directory. Both the RBRPro.API and the TestAddon project makes use of the TGD.Common.dll classes (<b>TGD.Localization</b> and <b>TGD.Framework</b> above all).
Select the folder &lt;RBRPro&gt;/Addons as the destination directory for the compiled files (where &lt;RBRPro&gt; is the root directory).

About
---------------------------
<b>TGD Localization Engine (TGD.Localization.Localizer)</b>

This is a small framework I wrote to allow the language switch in RBRPro... and you know how well it works... :)<br>
After evaluating other solutions, I've come to the conclusion that they didn't have the features I was looking for.
My localization engine is really simple to use but light and powerful at the same time. It make use of the "Tag" and "ToolTip" properties.
The language file is a simple .ini file. The <b>Load()</b> method of the <b>Localizer</b> class loads the iniFile into a C# Dictionary.
When you set Tag="SectionName. PropertyName" in the XAML, you help the engine to retrieve the property "PropertyName" in the section "SectionName" of its current language definition.
Once loaded the dictionary, the <b>Localizer</b>'s <b>Translate()</b> method translates the GUI by a recursive traversal of the whole WPF LogicalTree, starting from the element you provide as the root (usually the main window or control). For convenience, I  use a static class as a "proxy" for the Localizer, so that i can recall it from whatever point in the code.

<b>TGD ContextManager (TGD.Framework.ContextManager)</b>

This class is simple and sophisticated at the same time. It provides a convenient way to implement your view Model providing two kinds of properties: Config and Runtime properties, implemented respectively by the special attributes <b>[RuntimeProperties]</b> and <b>[ConfigProperties]</b>. 
Both the kinds of properties are "Observables" and then they are "ready" for WPF data binding. The class allows the use of multiple configuration files as well.<br>
[ConfigProperties] are automatically loaded and saved. You can use only simple C# types but this is not a big limitation.
The [RuntimeProperties] are instead the "volatile" ones. There is no limitation in their type, they can be also data Collections.
Together with the ObservableCollection class provided by the TGD.Framework package these classes are a good starting point to develop WPF based applications. Typically, you will set an instance of your implementation of the ContextManager as the GUI's DataContext.

<b>Add-ons</b>

An Add-on module for RRBRPro is a .NET based .dll class library exposing one or more classes implementing the <b>IRbrProAddOn</b> interface and (optionally) the <b>ITelemetryClient</b> interface. The manager provides an object called <b>interactor</b> to allow the interaction between the Add-On and the host application.
The interactor exposes a DOM referencing the main business entities. It also provide special events such as <b>LanguageChanged</b> that the Add-on can use to "react" to what is happening in the manager. Each entity is definend by an interface (IDriver, ICar, IStage, ICoDriver and so on).

Licensing
---------------------------
You are free to download and use this code for any non-commercial purposes. For commercial purposes please contact info.rbrpro@gmail.com
