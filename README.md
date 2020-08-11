# RbrPro-Addons
Want to develop an addon for the RBRPro manager? Welcome to the right place!

Since version 0.3.0.0 the RBRPro Manager supports Add-Ons. An NGP6 Telemetry server has been implemented. An add-on can act as a Telemetry client and receive telemetry data from the manager.

In other words the RBRProManager behaves in a way which is very similar to SimHub. It receives the NGP telemetry via UDP and can provide the data to its add-ons.
An add-on in basically a WPF Control hosted in the Add-Ons tab of the manager.

A working example is provided.
It is a complete Add-On with the following features:

1. Uses the TGD Localization engine to translate its GUI according to the lanaguage selected in the manager
2. Uses the Lightweight TGD MVVM framework for data binding and configuration persistence
3. Receive the telemetry and visualizes the car speed
4. Start the game from a command Button

Possible ideas for a new addon? 

- Hosting a new championship with its own calendar and rankings
- Implementing a driver for a motion simulator
- Implementing a co-driver engine (yes... TGD Navigator will be an addon...)


