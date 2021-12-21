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

namespace DustInTheWind.DeferredCustomAction.CustomActions
{
    public class LogSomethingCustomAction
    {
        // ====================================================================================================
        // Step 4: Implement the custom action
        // ====================================================================================================
        // 
        // Create a public static method having the CustomAction attribute on it.
        //
        // Being used as a deferred custom action, it cannot access the session properties, but it can access
        // the properties explicitly set from WiX by the associated custom action.
        //
        // END

        [CustomAction("LogSomething")]
        public static ActionResult Execute(Session session)
        {
            session.Log("==================== Begin LogSomething custom action ====================");

            try
            {
                session.Log("This is a demo, to show how to create and execute a deferred custom action.");

                // The values set by the associated custom action can be retrieved here, in C#,
                // from the "CustomActionData" collection.

                string message1 = session.CustomActionData["Message1"];
                session.Log("Message 1: " + message1);

                string message2 = session.CustomActionData["Message2"];
                session.Log("Message 2: " + message2);

                return ActionResult.Success;
            }
            finally
            {
                session.Log("==================== End LogSomething custom action ====================");
            }
        }
    }
}