public class CircularBuffer {

	private TRObject[] list;
	private int start, end, size;

	public CircularBuffer (int sizem){

		size = sizem;
		list = new TRObject[size];
		start = end = 0;

	}



	public void Push(TRObject obj){

		//überschreiben wir ein feld?
		if ((end + 1) % size == start)
			start = (start + 1) % size;

		list [end] = obj;
		end = (end + 1) % size; //damit wieder an anfang springen

	}

	public TRObject Pop(){

		//immer wenn end und start uafs gleiche feld zeigen , ist es leer

		if (end != start) {
			end = (end -1 + size) % size; //endepfeilchen rutscht um eins nach links
			return list[end];//wir tun so als würde es nicht mehr existieren
		}

		return null;
	}


	public void Clear()
	{
		for(int i = 0; i < size; i++)
			list[i] = null;
		start = end = 0;
	}

	public int Count {
		get{
			//alles zw. start und end
			return (end - start + size) % size;
		}
	}
}