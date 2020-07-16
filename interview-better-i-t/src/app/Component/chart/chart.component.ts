import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ChangeDetectorRef } from '@angular/core';


export interface ChartData {
  id: number;
  intent: string;
  subintent: string;
  point: number;
}


@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {




  constructor(private httpClient: HttpClient, private detector: ChangeDetectorRef) { }

  PieChart = [];
  Chart_datas: ChartData[] = [];
  Chart_data_point: number[] = [];
  Chart_data_intent_subintent: string[] = [];

  ngOnChanges(changes: Array<any>) {
    this.detector.detectChanges()
    // if detectChanges() doesn't work, try markForCheck()
  }

  ngOnInit(): void {

    this.getchartdata();

    var ctx = document.getElementById("pieChart");

    this.PieChart = new Chart(ctx, {
      type: 'pie',
      data: {
        label: "REST API CHART",
        labels: this.Chart_data_intent_subintent,
        datasets: [{

          data: this.Chart_data_point,
          //backgroundColor: fillPattern,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        title: {
          text: "REST API PIE CHART",
          display: true,
        },
        tooltips: {
          enabled: true
        },
        legend: {
          position: 'right',
          display: true,
          fullWidth: false,
          labels: {
            fontSize: 12
          }
        },
        plugins: {
          datalabels: {
            formatter: (value, ctx) => {

              let sum = 0;
              let dataArr = ctx.chart.data.datasets[0].data;
              dataArr.map(data => {
                sum += data;
              });
              let percentage = (value * 100 / sum).toFixed(2) + "%";
              return percentage;


            },
            color: '#fff',
          }
        }



      }
    });




    setInterval(() => { }, 100);
    //this.detector.detectChanges()

  }

  getchartdata() {
    this.httpClient.get("https://localhost:44399/api/charts").subscribe(
      body => {
        console.log("GET Request is successful ", body);
        for (let index = 0; index < body["length"]; index++) {
          this.Chart_datas.push({
            id: body[index].id,
            intent: body[index].intent,
            subintent: body[index].subintent,
            point: body[index].point
          })
          this.Chart_data_intent_subintent.push(body[index].intent + "-" + body[index].subintent);
          this.Chart_data_point.push(body[index].point);
        }
        console.log("Feed inter-sub is successful ", this.Chart_data_intent_subintent);
        console.log("Feed point is successful ", this.Chart_data_point);

      }, error => { console.log("Error", error); }
    );


  }

}
