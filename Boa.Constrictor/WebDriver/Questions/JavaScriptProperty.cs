﻿using Boa.Constrictor.Screenplay;
using OpenQA.Selenium;

namespace Boa.Constrictor.WebDriver
{
    /// <summary>
    /// Gets a web element's JavaScript property value.
    /// </summary>
    public class JavaScriptProperty : AbstractWebPropertyQuestion<string>
    {
        #region Constructors

        /// <summary>
        /// Private constructor.
        /// (Use static methods for public construction.)
        /// </summary>
        /// <param name="locator">The target Web element's locator.</param>
        /// <param name="propertyName">The property name.</param>
        private JavaScriptProperty(IWebLocator locator, string propertyName) : base(locator, propertyName) { }

        #endregion
        
        #region Builder Methods

        /// <summary>
        /// Constructs the Question.
        /// </summary>
        /// <param name="locator">The target Web element's locator.</param>
        /// <param name="named">The property name.</param>
        /// <returns></returns>
        public static JavaScriptProperty Of(IWebLocator locator, string named) => new JavaScriptProperty(locator, named);

        #endregion

        #region Methods

        /// <summary>
        /// Gets a web element's JavaScript property value.
        /// </summary>
        /// <param name="actor">The Screenplay Actor.</param>
        /// <param name="driver">The WebDriver.</param>
        /// <returns></returns>
        public override string RequestAs(IActor actor, IWebDriver driver)
        {
            actor.WaitsUntil(Existence.Of(Locator), IsEqualTo.True());
            return driver.FindElement(Locator.Query).GetProperty(PropertyName);
        }

        /// <summary>
        /// Returns a description of the Question.
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            $"JavaScript of '{PropertyName}' for '{Locator.Description}'";

        #endregion
    }
}
