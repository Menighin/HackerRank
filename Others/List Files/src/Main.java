import javafx.util.Pair;

import java.io.File;
import java.util.ArrayList;
import java.util.Stack;

public class Main {
    public static void main(String[] args) {

        File root = new File("D:\\Projects\\luwak\\src\\main\\java\\com");

		Stack<Pair<String, File>> stack = new Stack<Pair<String, File>>();
		stack.push(new Pair<String, File>("com", root));

		ArrayList<String> classes = new ArrayList<String>();

		while (!stack.isEmpty()) {
			Pair<String, File> item = stack.pop();

			for (File f : item.getValue().listFiles()) {
				if (f.isDirectory()) {
					stack.push(new Pair<String, File>(item.getKey() + "." + f.getName(), f));
				} else {
					classes.add(item.getKey() + "." + f.getName().split("\\.")[0]);
				}
			}
		}

		for (String clazz : classes) {
			System.out.println(clazz);
		}

    }
}
