using UnityEngine;
using System.Collections;

public class logic : MonoBehaviour {
	public GameObject field;
	GameObject [,] array;
	int xx = 9; // Размер поля
	int yy = 13;
	int xxx = 4; // Начальное положения объекта по ширине
	int yyy = 11; // По высоте
	float time = 1;
	bool shift = false;
	int tilt;
	bool nautilus = true;
	bool check = false;
	int number = 0;
	
	void Update(){
		time -= Time.deltaTime;
		if(time < 0){
			time = 1;}
		if(check){
			for(int z = 0; z < 4; z++){ // Цикл проверки по рядам	
				for(int y = 0; y < array.GetLength(1); y++){
					if(y >= 0){
						int i = y; // Будет принимать текущий ряд для сравнения
						if(array[0,y].GetComponent<Renderer>().enabled == true && 
						   array[1,y].GetComponent<Renderer>().enabled == true && 
						   array[2,y].GetComponent<Renderer>().enabled == true && 
						   array[3,y].GetComponent<Renderer>().enabled == true && 
						   array[4,y].GetComponent<Renderer>().enabled == true && 
						   array[5,y].GetComponent<Renderer>().enabled == true && 
						   array[6,y].GetComponent<Renderer>().enabled == true && 
						   array[7,y].GetComponent<Renderer>().enabled == true && 
						   array[8,y].GetComponent<Renderer>().enabled == true){
							for(int x = 0; x < array.GetLength(0); x++){ // Очистка ряда
								array[x, y].GetComponent<Renderer>().enabled = false;
							}
							for(int x = 0; x < array.GetLength(0); x++){ // Цикл смещения
								for(y = i; y < array.GetLength(1); y++){ 
									if(array[x, y].GetComponent<Renderer>().enabled == true){
										array[x, y].GetComponent<Renderer>().enabled = false;
										array[x, y - 1].GetComponent<Renderer>().enabled = true;
									}
								}
							}
						}
					}
				}
			}
			
			number = Random.Range(0, 2);
			if(number == 0){
				tilt = 0;
			}
			if(number == 1){
				tilt = 90;
			}
			if(number == 2){
				tilt = 180;
			}
			xxx = 4; 
			yyy = 11;
			check = false;
			nautilus = true;
		}
		
		if(Input.GetButtonUp("Jump")){
			tilt += 90;
			if(tilt == 90){
				array[xxx, yyy].GetComponent<Renderer>().enabled = false; // Центр
				array[xxx, yyy - 1].GetComponent<Renderer>().enabled = false; // Центр зад 
				array[xxx + 1, yyy - 1].GetComponent<Renderer>().enabled = false; // Центр вверх
				array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false; // Центр вниз
				
				array[xxx, yyy].GetComponent<Renderer>().enabled = true; // Центр 
				array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true; // Центр зад
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = true; // Центр влево
				array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = true; // Центр вправо
				nautilus = true;
			}
			
			if(tilt == 180){
				array[xxx, yyy].GetComponent<Renderer>().enabled = false;
				array[xxx - 1, yyy].GetComponent<Renderer>().enabled = false;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
				array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
				
				array[xxx, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx + 1, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = true;
				nautilus = true;
			}
		}
		
		if(tilt == 180){
			if(nautilus){
				array[xxx, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx + 1, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = true;
				nautilus = false;
			}
			if(time < 1 && time > 0.98f){
				shift = true;
			}
			if(time < 0.98f && time > 0.96f){
				if(shift){
					if(yyy == 0){
						check =  true;
					}
					if(yyy > 0 && array[xxx, yyy - 1].GetComponent<Renderer>().enabled == true || yyy > 0 && array[xxx + 1, yyy].GetComponent<Renderer>().enabled == true || yyy > 0  && array[xxx - 1, yyy].GetComponent<Renderer>().enabled == true)
						check = true;
				}
				if(yyy > 0 && array[xxx, yyy - 1].GetComponent<Renderer>().enabled == false && array[xxx + 1, yyy].GetComponent<Renderer>().enabled == false && array[xxx - 1, yyy].GetComponent<Renderer>().enabled == false){
					array[xxx, yyy].GetComponent<Renderer>().enabled = false;
					array[xxx, yyy + 1].GetComponent<Renderer>().enabled = false;
					array[xxx + 1, yyy + 1].GetComponent<Renderer>().enabled = false;
					array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
					
					array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
					array[xxx, yyy].GetComponent<Renderer>().enabled = true;
					array[xxx + 1, yyy].GetComponent<Renderer>().enabled = true;
					array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true;
					yyy--;
					shift = false;
				}
			}
		}
		
		if(yyy > 0){
			if(Input.GetKeyUp(KeyCode.S) && array[xxx, yyy - 1].GetComponent<Renderer>().enabled == false && array[xxx + 1, yyy].GetComponent<Renderer>().enabled == false && array[xxx - 1, yyy].GetComponent<Renderer>().enabled == false){
				array[xxx, yyy].GetComponent<Renderer>().enabled = false;
				array[xxx, yyy + 1].GetComponent<Renderer>().enabled = false;
				array[xxx + 1, yyy + 1].GetComponent<Renderer>().enabled = false;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
				
				array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
				array[xxx, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx + 1, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true;
				yyy--;
			}
		}
		
		if(xxx > 1){ 
			if(Input.GetKeyUp(KeyCode.A) && array[xxx - 1, yyy].GetComponent<Renderer>().enabled == false && array[xxx - 2, yyy + 1].GetComponent<Renderer>().enabled == false){
				array[xxx, yyy].GetComponent<Renderer>().enabled = false;
				array[xxx, yyy + 1].GetComponent<Renderer>().enabled = false;
				array[xxx + 1, yyy + 1].GetComponent<Renderer>().enabled = false;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
				
				array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx - 2, yyy + 1].GetComponent<Renderer>().enabled = true;
				xxx--;
			}
		}
		
		if(xxx < xx - 2){
			if(Input.GetKeyUp(KeyCode.D) && array[xxx + 1, yyy].GetComponent<Renderer>().enabled == false && array[xxx + 2, yyy + 1].GetComponent<Renderer>().enabled == false){
				array[xxx, yyy].GetComponent<Renderer>().enabled = false;
				array[xxx, yyy + 1].GetComponent<Renderer>().enabled = false;
				array[xxx + 1, yyy + 1].GetComponent<Renderer>().enabled = false;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
				
				array[xxx + 1, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx + 1, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx + 2, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx, yyy + 1].GetComponent<Renderer>().enabled = true;
				xxx++;
			}
		}
		
		if(tilt == 90){
			if(nautilus){
				array[xxx, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true;
				array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = true;
				array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = true;
				nautilus = false;
			}
			if(time < 1 && time > 0.98f){
				shift = true;
			}
			if(time < 0.98f && time > 0.96f){
			if(shift){
				if(yyy == 1){ 
					check = true;
				}
				if(yyy > 1 && array[xxx, yyy - 1].GetComponent<Renderer>().enabled == true || yyy > 1 && array[xxx - 1, yyy - 2].GetComponent<Renderer>().enabled == true){
					check = true;
				}
				if(yyy > 1 && array[xxx, yyy - 1].GetComponent<Renderer>().enabled == false && array[xxx - 1, yyy - 2].GetComponent<Renderer>().enabled == false){
					array[xxx, yyy].GetComponent<Renderer>().enabled = false;
					array[xxx - 1, yyy].GetComponent<Renderer>().enabled = false;
					array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
					array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
					
					array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
					array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = true;
					array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true;
					array[xxx - 1, yyy - 2].GetComponent<Renderer>().enabled = true;
					yyy--;
					}
				}
				if(xxx > 1){
					if(Input.GetKeyUp(KeyCode.A) && array[xxx - 2, yyy].GetComponent<Renderer>().enabled == false && array[xxx - 2, yyy + 1].GetComponent<Renderer>().enabled == false && array[xxx - 2, yyy - 1].GetComponent<Renderer>().enabled == false){
						array[xxx, yyy].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						
						array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true;
						array[xxx - 2, yyy].GetComponent<Renderer>().enabled = true;
						array[xxx - 2, yyy + 1].GetComponent<Renderer>().enabled = true;
						array[xxx - 2, yyy - 1].GetComponent<Renderer>().enabled = true;
						xxx--;
					}
				}
				if(xxx < xx - 1){ 
					if(Input.GetKeyUp(KeyCode.D) && array[xxx + 1, yyy].GetComponent<Renderer>().enabled == false && array[xxx, yyy + 1].GetComponent<Renderer>().enabled == false && array[xxx, yyy - 1].GetComponent<Renderer>().enabled == false){
						array[xxx, yyy].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy + 1].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						
						array[xxx + 1, yyy].GetComponent<Renderer>().enabled = true;
						array[xxx, yyy].GetComponent<Renderer>().enabled = true;
						array[xxx, yyy + 1].GetComponent<Renderer>().enabled = true;
						array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
						xxx++;
					}
				}
			}
			if(tilt == 0){
				if(nautilus){
					array[xxx, yyy].GetComponent<Renderer>().enabled = true;
					array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
					array[xxx + 1, yyy - 1].GetComponent<Renderer>().enabled = true;
					array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = true;
					nautilus = false;
				}
				if(time < 1 && time > 0.98f){
					shift = true;
				}
				if(time < 0.98f && time > 0.96f){
					if(shift){
						if(yyy == 1){
							check = true;
						}
						if(yyy > 1 && array[xxx, yyy - 2].GetComponent<Renderer>().enabled == true || yyy > 1 && array[xxx + 1, yyy - 2].GetComponent<Renderer>().enabled == true || yyy > 1 && array[xxx - 1, yyy - 2].GetComponent<Renderer>().enabled == true){
							check = true;
						}
						if(yyy > 1 && array[xxx, yyy - 2].GetComponent<Renderer>().enabled == false && array[xxx + 1, yyy - 2].GetComponent<Renderer>().enabled == false && array[xxx - 1, yyy - 2].GetComponent<Renderer>().enabled == false){
							array[xxx, yyy].GetComponent<Renderer>().enabled = false;
							array[xxx, yyy - 1].GetComponent<Renderer>().enabled = false;
							array[xxx + 1, yyy - 1].GetComponent<Renderer>().enabled = false;
							array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
							
							array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
							array[xxx, yyy - 2].GetComponent<Renderer>().enabled = true;
							array[xxx + 1, yyy - 2].GetComponent<Renderer>().enabled = true;
							array[xxx - 1, yyy - 2].GetComponent<Renderer>().enabled = true;
							yyy--;
							shift = false;
						}
					}
				}
				if(yyy > 1){
					if(Input.GetKeyUp(KeyCode.S) && array[xxx, yyy - 2].GetComponent<Renderer>().enabled == false && array[xxx + 1, yyy - 2].GetComponent<Renderer>().enabled == false && array[xxx -1, yyy - 2].GetComponent<Renderer>().enabled == false){
						array[xxx, yyy].GetComponent<Renderer>().enabled = false;
						array[xxx, yyy - 1].GetComponent<Renderer>().enabled = false;
						array[xxx + 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						
						array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
						array[xxx, yyy - 2].GetComponent<Renderer>().enabled = true;
						array[xxx + 1, yyy - 2].GetComponent<Renderer>().enabled = true;
						array[xxx - 1, yyy - 2].GetComponent<Renderer>().enabled = true;
						yyy--;
					}
				}
				if(xxx > 1){
				if(Input.GetKeyUp(KeyCode.A) && array[xxx - 2, yyy - 1].GetComponent<Renderer>().enabled == false && array[xxx - 1, yyy].GetComponent<Renderer>().enabled == false){
						array[xxx, yyy].GetComponent<Renderer>().enabled = false;
						array[xxx, yyy - 1].GetComponent<Renderer>().enabled = false;
						array[xxx + 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						
						array[xxx - 1, yyy].GetComponent<Renderer>().enabled = true;
						array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = true;
						array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
						array[xxx - 2, yyy - 1].GetComponent<Renderer>().enabled = true;
						xxx--;
					}
				}
				if(xxx < xx - 2){ 
					if(Input.GetKeyUp(KeyCode.D) && array[xxx + 2, yyy - 1].GetComponent<Renderer>().enabled == false && array[xxx + 1, yyy].GetComponent<Renderer>().enabled == false){
						array[xxx, yyy].GetComponent<Renderer>().enabled = false;
						array[xxx, yyy - 1].GetComponent<Renderer>().enabled = false;
						array[xxx + 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						array[xxx - 1, yyy - 1].GetComponent<Renderer>().enabled = false;
						
						array[xxx + 1, yyy].GetComponent<Renderer>().enabled = true;
						array[xxx + 1, yyy - 1].GetComponent<Renderer>().enabled = true;
						array[xxx + 2, yyy - 1].GetComponent<Renderer>().enabled = true;
						array[xxx, yyy - 1].GetComponent<Renderer>().enabled = true;
						xxx++;
					}
				}
			}
		}
	}
		void Start(){
			array = new GameObject[xx, yy];
			for(int x = 0; x < xx; x++){
				for(int y = 0; y < yy; y++){
					array[x, y] = (GameObject)Instantiate(field, new Vector3(x, y, 0), Quaternion.identity);
					array[x, y].GetComponent<Renderer>().enabled = false;
				}
			}
			number = Random.Range(0, 3);
			if(number == 0){
				tilt = 0;
			}
			if(number == 1){
				tilt = 90;
			}
			if(number == 2){
				tilt = 180;
			}
		}
	}






























