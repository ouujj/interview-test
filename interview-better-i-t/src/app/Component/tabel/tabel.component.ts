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

  getEnglishwithThai(){

    this.httpClient.get('https://localhost:44399/api/Englishes/withthaiall').subscribe(
      body => {
        this.EnginTh_dataSource = body;
        console.log("GET English Request is successful ", body);
      }, error => { console.log("Error", error); }
    );
  }

  ngOnInit(): void {
      this.getEnglishwithThai();
  }

}

