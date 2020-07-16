import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface English {
  id: number;
  word: string;
}



export interface Thai {
  id: number;
  word: string;
  EngId: number;
}
export interface English_incluide_Thai {
  id: number;
  word: string;
  thai: Thai[];
}

const ELEMENT_DATA: any[] = [
  {
    position: 1, name: [{ SYNONYMS: 'Fluorine1', symbol: 'F' },
    { SYNONYMS: 'Fluorine2', symbol: 'F' },
    { SYNONYMS: 'Fluorine3', symbol: 'F' }]
  },
  {
    position: 2, name: [{ SYNONYMS: 'Neon1', symbol: 'Ne' },
    { SYNONYMS: 'Neon2', symbol: 'Ne' }]
  },

];

@Injectable()
@Component({
  selector: 'app-tabel',
  templateUrl: './tabel.component.html',
  styleUrls: ['./tabel.component.css']
})
export class TabelComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }

  displayedColumns: string[] = ['VALUE', 'SYNONYMS'];

  private EnglishWord: string;

  dataSource = ELEMENT_DATA;

  English_dataSource: any = {};

  Thai_dataSource: any = {};

  EnginTh_dataSource: any = {};
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];


  add(event: MatChipInputEvent, engid: number): void {
    const input = event.input;
    const value = event.value;
    console.log(engid);
    // Add our fruit
    if ((value || '').trim()) {
      this.Thai_dataSource.push({ word: value.trim() });
      console.log(value.trim(), engid);
      this.addThaiword(value.trim(), engid).subscribe(data => {
        console.log("Update Success", data);
      },
        error => {
          console.log("Fail", error);
        });
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  remove(thaiword: Thai): void {
    const index = this.Thai_dataSource.indexOf(thaiword);

    //this.deleteThaiword(this.Thai_dataSource[index]["id"]);

    if (index >= 0) {
      // console.log("Delect Thaiword id : ",this.Thai_dataSource[index]["id"], this.Thai_dataSource[index] );
      //console.log('http://localhost:44399/api/Thais/',this.Thai_dataSource[index]["id"]);

      //rest api delete
      this.deleteThaiword(this.Thai_dataSource[index]["id"]).subscribe(data => {
        this.Thai_dataSource.splice(index, 1);
        console.log("Delete Success", data);
      },
        error => {
          console.log("Delete Fail", error);
        });

    }
  }

  deleteThaiword(id: number): Observable<any> {
    console.log("Try to Delect By api: ", 'https://localhost:44399/api/Thais/' + id);
    return this.httpClient.delete('https://localhost:44399/api/Thais/' + id);
  }

  addEnglishWord() {
    //console.log('ds');
    if (this.EnglishWord != null) {
      this.addEnglishWordApi(this.EnglishWord).subscribe(data => {

        console.log("Add new English Success", data);
      },
        error => {
          console.log("Add new English Fail", error);
        });

    }
  }

  addThaiword(word: string, engid: number) {
    //console.log(word,engid);
    return this.httpClient.post('https://localhost:44399/api/Thais', {
      'word': word,
      'engId': engid
    })

  }
  addEnglishWordApi(word: string) {

    return this.httpClient.post('https://localhost:44399/api/Englishes', {
      'word': word
    })
  }

  getEnglish() {
    this.httpClient.get('https://localhost:44399/api/Englishes').subscribe(
      body => {
        this.English_dataSource = body;
        console.log("GET English Request is successful ", body);
      }, error => { console.log("Error", error); }
    );
  }

  getThai() {
    this.httpClient.get('https://localhost:44399/api/Thais').subscribe(
      body => {
        this.Thai_dataSource = body;
        console.log("GET Thai Request is successful ", body);

        this.getEng_include_thai();


      }, error => { console.log("Error", error); }
    );
  }

  getEng_include_thai() {
    let buf_engwiththai = [];
    //  console.log("thai length:",this.Thai_dataSource["length"]);
    // var index = this.English_dataSource.findIndex(obj => obj.word==this.Thai_dataSource[0]["engId"]);
    //  console.log(index);
    for (let indexEng = 0; indexEng < this.English_dataSource["length"]; indexEng++) {
      //console.log("thai index:",index);
      /*   this.EnginTh_dataSource.push({
           id: this.English_dataSource[indexEng]["id"],
           word:this.English_dataSource[indexEng]["word"]
         });
       */
      for (let indexTh = 0; indexTh < this.Thai_dataSource["length"]; indexTh++) {
        //console.log("thai index:",index);

        if (this.Thai_dataSource[indexTh]["engId"] == this.English_dataSource[indexEng]["id"]) {
          console.log(this.Thai_dataSource[indexTh]["word"], this.English_dataSource[indexEng]["word"]);
          //buf_engwiththai[indexEng] =  this.English_dataSource[indexEng]


        }
      }
    }
    console.log(this.EnginTh_dataSource);
  }

  ngOnInit(): void {
    this.getEnglish();
    this.getThai();
    // this.getEng_include_thai();
  }

}

