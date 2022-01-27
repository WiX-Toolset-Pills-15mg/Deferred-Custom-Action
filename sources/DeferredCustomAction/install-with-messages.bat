:: ====================================================================================================
:: Step 10: Run the installer
:: ====================================================================================================
::
:: Install the MSI and look into the "install-with-messages.log" file.
::
:: You will be able to find the "LogMessages" custom action executed where we scheduled it, after the
:: "InstallInitialize" custom action, but the C# function is not executed there. It is actually
:: executed later, at the end of the installation sequence, inside the "InstallFinalize" custom action.
:: There we can find the messages that we wrote from the C# implementation.
::
:: END

msiexec /i DeferredCustomAction.msi /l*vx install-with-messages.log MESSAGE1="This is the custom message 1." MESSAGE2="This is the custom message 2."