﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

// Instance of this class can be created as assets.
// Each instance contains collections of data from
// the Saver monobehaviours they have been referenced
// by.  Since assets exist outside of the scene, the
// data will persist ready to be reloaded next time
// the scene is loaded.  Note that these assets
// DO NOT persist between loads of a build and can
// therefore NOT be used for saving the gamestate to
// disk.
[CreateAssetMenu]
public class SaveData : ResettableScriptableObject
{
    // This nested class is a lighter replacement for
    // Dictionaries.  This is required because Dictionaries
    // are not serializable.  It has a single generic type
    // that represents the type of data to be stored in it.
    [Serializable]
    public class KeyValuePairLists<T>
    {
        public List<string> keys = new List<string>();      // The keys are unique identifiers for each element of data. 
        public List<T> values = new List<T>();              // The values are the elements of data.


        public void Clear ()
        {
            keys.Clear ();
            values.Clear ();
        }


        public void TrySetValue (string key, T value)
        {
            // Find the index of the keys and values based on the given key.
            int index = keys.FindIndex(x => x == key);

            // If the index is positive...
            if (index > -1)
            {
                // ... set the value at that index to the given value.
                values[index] = value;
            }
            else
            {
                // Otherwise add a new key and a new value to the collection.
                keys.Add (key);
                values.Add (value);
            }
        }


        public bool TryGetValue (string key, ref T value)
        {
            // Find the index of the keys and values based on the given key.
            int index = keys.FindIndex(x => x == key);

            // If the index is positive...
            if (index > -1)
            {
                // ... set the reference value to the value at that index and return that the value was found.
                value = values[index];
                return true;
            }

            // Otherwise, return that the value was not found.
            return false;
        }
    }


    // These are collections for various different data types.
    public KeyValuePairLists<bool> boolKeyValuePairLists = new KeyValuePairLists<bool> ();
    public KeyValuePairLists<int> intKeyValuePairLists = new KeyValuePairLists<int>();
    public KeyValuePairLists<string> stringKeyValuePairLists = new KeyValuePairLists<string>();
    public KeyValuePairLists<Vector3> vector3KeyValuePairLists = new KeyValuePairLists<Vector3>();
    public KeyValuePairLists<Quaternion> quaternionKeyValuePairLists = new KeyValuePairLists<Quaternion>();
	//public KeyValuePairLists<Item> itemKeyValuePairLists = new KeyValuePairLists<Item>();

    public override void Reset ()
    {
        boolKeyValuePairLists.Clear ();
        intKeyValuePairLists.Clear ();
        stringKeyValuePairLists.Clear ();
        vector3KeyValuePairLists.Clear ();
        quaternionKeyValuePairLists.Clear ();
		//itemKeyValuePairLists.Clear ();
    }


    // This is the generic version of the Save function which takes a
    // collection and value of the same type and then tries to set a value.
    private void Save<T>(KeyValuePairLists<T> lists, string key, T value)
    {
        lists.TrySetValue(key, value);
    }


    // This is similar to the generic Save function, it tries to get a value.
    private bool Load<T>(KeyValuePairLists<T> lists, string key, ref T value)
    {
        return lists.TryGetValue(key, ref value);
    }


    // This is a public overload for the Save function that specifically
    // chooses the generic type and calls the generic version.
    public void Save (string key, bool value)
    {
        Save(boolKeyValuePairLists, key, value);
    }


    public void Save (string key, int value)
    {
        Save(intKeyValuePairLists, key, value);
    }


    public void Save (string key, string value)
    {
        Save(stringKeyValuePairLists, key, value);
    }


    public void Save (string key, Vector3 value)
    {
        Save(vector3KeyValuePairLists, key, value);
    }


    public void Save (string key, Quaternion value)
    {
        Save(quaternionKeyValuePairLists, key, value);
    }

	/*public void Save (string key, Item value)
	{
		Save(itemKeyValuePairLists, key, value);
	}*/


    // This works the same as the public Save overloads except
    // it calls the generic Load function.
    public bool Load (string key, ref bool value)
    {
        return Load(boolKeyValuePairLists, key, ref value);
    }


    public bool Load (string key, ref int value)
    {
        return Load (intKeyValuePairLists, key, ref value);
    }


    public bool Load (string key, ref string value)
    {
        return Load (stringKeyValuePairLists, key, ref value);
    }


    public bool Load (string key, ref Vector3 value)
    {
        return Load(vector3KeyValuePairLists, key, ref value);
    }


    public bool Load (string key, ref Quaternion value)
    {
        return Load (quaternionKeyValuePairLists, key, ref value);
    }

	/*public bool Load (string key, ref Item value)
	{
		return Load (itemKeyValuePairLists, key, ref value);
	}*/


	//Save/Load to/from disk methods
	public void SaveToDisk(){
		Serializer.Serialize (this.name + "Bool.dat", boolKeyValuePairLists);
		Serializer.Serialize (this.name + "Int.dat", intKeyValuePairLists);
		Serializer.Serialize (this.name + "String.dat", stringKeyValuePairLists);
		Serializer.Serialize (this.name + "Vector3.dat", vector3KeyValuePairLists);
		Serializer.Serialize (this.name + "Quaternion.dat", quaternionKeyValuePairLists);
		//Serializer.Serialize (this.name + "Item.dat", itemKeyValuePairLists);
	}

	public void LoadFromDisk(){
		Serializer.Deserialize (this.name + "Bool.dat", ref boolKeyValuePairLists);
		Serializer.Deserialize (this.name + "Int.dat", ref intKeyValuePairLists);
		Serializer.Deserialize (this.name + "String.dat", ref stringKeyValuePairLists);
		Serializer.Deserialize(this.name + "Vector3.dat", ref vector3KeyValuePairLists);
		Serializer.Deserialize(this.name + "Quaternion.dat", ref quaternionKeyValuePairLists);
		//Serializer.Deserialize(this.name + "Item.dat", ref itemKeyValuePairLists);
	}
		
	//need to be in an independent class to avoid stack overflows caused by having both the generic and overloaded method accessible
	public class Serializer{
		
		//generic serialization to disk method
		public static void Serialize<T>(string filename, SaveData.KeyValuePairLists<T> data)
		{
			BinaryFormatter bf = new BinaryFormatter ();

			//adds the surrogate selector to allow system serialization of unity types
			SurrogateSelector surrogateSelector = new SurrogateSelector();
			//adds the surrogate selector to allow system serialization of Vector3
			Vector3SerializationSurrogate vector3SS = new Vector3SerializationSurrogate();
			//adds the surrogate selector to allow system serialization of Quaternion
			QuaternionSerializationSurrogate quaternionSS = new QuaternionSerializationSurrogate();

			surrogateSelector.AddSurrogate(typeof(Vector3),new StreamingContext(StreamingContextStates.All),vector3SS);
			surrogateSelector.AddSurrogate(typeof(Quaternion),new StreamingContext(StreamingContextStates.All),quaternionSS);
			bf.SurrogateSelector = surrogateSelector;

			string saveDataPath = Application.persistentDataPath + "/GameSave/";

			if (!Directory.Exists(saveDataPath)) {
				Directory.CreateDirectory(saveDataPath);
			}

			FileStream file = File.Create(saveDataPath + filename); //Application.persistentDataPath
			bf.Serialize (file, data);
			file.Close();
		}

		//genereic deserialisation from disk method
		public static void Deserialize<T>(string filename, ref KeyValuePairLists<T> data)
		{
			string saveDataPath = Application.persistentDataPath + "/GameSave/";

			if (!Directory.Exists(saveDataPath)) {
				Directory.CreateDirectory(saveDataPath);
			}


			if (File.Exists (saveDataPath + filename)) { //Application.persistentDataPath
				BinaryFormatter bf = new BinaryFormatter ();

				//adds the surrogate selector to allow system serialization of unity types
				SurrogateSelector surrogateSelector = new SurrogateSelector();
				//adds the surrogate selector to allow system serialization of Vector3
				Vector3SerializationSurrogate vector3SS = new Vector3SerializationSurrogate();
				//adds the surrogate selector to allow system serialization of Quaternion
				QuaternionSerializationSurrogate quaternionSS = new QuaternionSerializationSurrogate();

				surrogateSelector.AddSurrogate(typeof(Vector3),new StreamingContext(StreamingContextStates.All),vector3SS);
				surrogateSelector.AddSurrogate(typeof(Quaternion),new StreamingContext(StreamingContextStates.All),quaternionSS);
				bf.SurrogateSelector = surrogateSelector;

				FileStream file = File.Open(saveDataPath +  filename, FileMode.Open);
				data = (KeyValuePairLists<T>) bf.Deserialize (file);
				file.Close();
			}
		}

		//serialisation to disk overloads
		private void Serialize(string filename, SaveData.KeyValuePairLists<bool> data)
		{
			Serialize (filename, data);
		}

		private void Serialize(string filename, SaveData.KeyValuePairLists<int> data)
		{
			Serialize (filename, data);
		}

		private void Serialize(string filename, SaveData.KeyValuePairLists<string> data)
		{
			Serialize (filename, data);
		}

		private void Serialize(string filename, SaveData.KeyValuePairLists<Vector3> data)
		{
			Serialize (filename, data);
		}

		private void Serialize(string filename, SaveData.KeyValuePairLists<Quaternion> data)
		{
			Serialize (filename, data);
		}

		/*private void Serialize(string filename, SaveData.KeyValuePairLists<Item> data)
		{
			Serialize (filename, data);
		}*/


		// deserialisation overloads
		private void Deserialize(string filename, ref KeyValuePairLists<bool> data)
		{
			Deserialize (filename, ref data);
		}

		private void Deserialize(string filename, ref KeyValuePairLists<int> data)
		{
			Deserialize (filename, ref data);
		}

		private void Deserialize(string filename, ref KeyValuePairLists<string> data)
		{
			Deserialize (filename, ref data);
		}

		private void Deserialize(string filename, ref KeyValuePairLists<Vector3> data)
		{
			Deserialize (filename, ref data);
		}

		private void Deserialize(string filename, ref KeyValuePairLists<Quaternion> data)
		{
			Deserialize (filename, ref data);
		}

		/*private void Deserialize(string filename, ref KeyValuePairLists<Item> data)
		{
			Deserialize (filename, ref data);
		}*/
	}
}
