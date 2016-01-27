/*
 * Author: Morteza
 * Date: 1/27/2016
 * Time: 5:10 PM
 * Copyright: Binary Ltd
 * 
 */
 
 
using System;

namespace BinaryWebsocketDemo
{
  public class Program
  {
    public static void Main (string[] args)
    {
		WebSocketWrapper ws = WebSocketWrapper.Create("wss://ws.binaryws.com/websockets/v3");
		ws.Connect();
		ws.OnMessage(OnMessage);
		ws.OnDisconnect(OnDisconnect);
		ws.OnConnect(OnConnect);
		
		Console.ReadKey(true);
    }
    
    public static void OnMessage(string e, WebSocketWrapper sender){
    	Console.WriteLine ("Binary says: " + e.ToString());
    }
    
    public static void OnDisconnect(WebSocketWrapper sender){
    	Console.WriteLine("WebSocket is closed: ");
    }
    
    public static void OnConnect(WebSocketWrapper sender){
    	sender.SendMessage("{\"ticks\": \"R_100\"}");
    }
  }
}