// WiX Toolset Pills 15mg
// Copyright (C) 2019-2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Microsoft.Deployment.WindowsInstaller;

// ====================================================================================================
// Step 2: Create the C# custom actions project
// ====================================================================================================
// 
// A custom action project is a class library with additional instructions that creates the *.CA.dll
// file as a wrapper over the normal .NET dll assembly.
// This is necessary because Windows Installer is not able to consume .NET assemblies directly. This
// *.CA.dll acts as an adapter.
// 
// Note: Because of this, make sure to always create a project of type "C# Custom Action Project for
//       WiX v3" and not a normal class library project.
// 
// NEXT: LogMessagesCustomAction.cs (DOWN)

namespace DustInTheWind.DeferredCustomAction.CustomActions
{
    public class LogMessagesCustomAction
    {
        // ====================================================================================================
        // Step 3: Create the custom action function
        // ====================================================================================================
        // 
        // Create a public static method having the [CustomAction] attribute on it. This is the function
        // referenced in the custom action tag from WiX.
        // 
        // Being used by a deferred custom action, and executed at the end of the installation, this function
        // cannot access the session properties anymore as we do in an immediate custom action. We'll need a
        // different mechanism.
        // 
        // WiX Toolset provides a way of sending values to the deferred custom action (we'll see later how)
        // and they are retrieved in C# using the "CustomActionData" collection.
        // 
        // NEXT: CustomActions.wxs

        [CustomAction("LogMessages")]
        public static ActionResult Execute(Session session)
        {
            session.Log("--> Begin LogSomething custom action");
            try
            {
                string message1 = session.CustomActionData["Message1"];
                session.Log("Message 1: " + message1);

                string message2 = session.CustomActionData["Message2"];
                session.Log("Message 2: " + message2);

                return ActionResult.Success;
            }
            finally
            {
                session.Log("--> End LogSomething custom action");
            }
        }
    }
}