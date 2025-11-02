
# Inventory Management System
Colors: (85, 113, 73), (117, 145, 105), (110, 40, 5)
Fonts: Lucida Fax, Maiandra GD, Cambria, Calibri, Segoe UI

# Apply Text Wrapping for Long Product Names
string productname = row.Cells["ProductName"].Value.ToString();

// Limit text width so it wraps
int textwidth = 230;
SizeF textsize = e.Graphics.MeasureString(productname, font, textwidth);

// Draw wrapped product name
e.Graphics.DrawString(productname, font, Brushes.Black,
    new RectangleF(left, y, textwidth, textsize.Height));

// Move Y down based on text height
y += (int)textSize.Height + 5;


