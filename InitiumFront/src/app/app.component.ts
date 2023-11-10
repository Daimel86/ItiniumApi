import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Initium';
  queues: any[] = [];

  constructor(private httpClient: HttpClient) {
  }

  addClient(id: HTMLInputElement, name: HTMLInputElement) {
    this.httpClient.post("http://localhost:5207/Clients", {id: +id.value, clientName: name.value})
      .subscribe({
        next: (el: any) => {
          const i = this.queues.findIndex(f => f.id === el.queueId)
          this.queues[i].clients.push(el)
          console.log("Respuesta exitosa:", el)
          id.value = ""
          name.value = ""
        }, error: err => {
          if (err instanceof HttpErrorResponse && err.error && err.error.errors) {
            const errorMessages = Object.values(err.error.errors)
              .flat()
              .join('\n');

            alert(errorMessages);
          } else if (err.error && err.error.title) {
            alert(err.error.title);
          } else {
            console.log(err.error)
            alert("Error al agregar el cliente. Por favor, verifica los datos e intenta nuevamente.");
          }

        }
      })
  }

  ngOnInit(): void {
    this.loadQueues();
  }

  loadQueues() {
    this.httpClient.get("http://localhost:5207/Queues").subscribe({
      next: (arr: any) => {
        this.queues = arr
      }, error: err => {
        console.error("Error al cargar las colas:", err);

      }
    });
  }
}
