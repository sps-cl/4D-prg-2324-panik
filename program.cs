class Rectangle {
    private int w;
    private int h;

    void draw() {

    }

    private void ChangeShape() {
        Console.WriteLine("měním");
    }
}

class program {
    public static void Main (string[] args) {
        Rectangle r1 = new Rectangle();
        r1.Render();
    }
}