using System;


namespace ImagEd.Framework {
    internal class Flip {
        public enum Mode {
            // No flip.
            None,
            // Flip horizontally.
            FlipHorizontally,
            // Flip vertically.
            FlipVertically,
             //Flip both.
            FlipBoth
        }

        public static Mode ParseEnum(string flip) {
            return Enum.TryParse<Mode>(flip, true, out Mode mode) ? mode : Mode.None;
        }
    }
}