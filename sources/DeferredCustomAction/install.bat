:: ====================================================================================================
:: Step 10: Run the installer
:: ====================================================================================================
::
:: Install the MSI and look into the "install.log" file.
::
:: You will be able to find the "LogSomething" custom action executed as we scheduled it, after the
:: "InstallFiles" suctom action, but the C# function is not executed there. It actual executed later,
:: at the end of the installation sequence, inside the "InstallFinalize" custom action. There we find
:: the messages that we wrote from the C# implementation.
::
:: END

msiexec /i DeferredCustomAction.msi /l*vx install.log MESSAGE1="This is the custom message 1." MESSAGE2="This is the custom message 2."