import http from 'k6/http'
import { check, sleep } from 'k6'

export const options = {
    stages: [
        { duration: '1m', target: 100 },
        { duration: '3m', target: 100 },
        { duration: '1m', target: 0 },

    ],
    thresholds: {
        checks: ['rate > 0.99'],
        http_req_duration: ['p(95) < 150']
    }
}

export default function () {
    let filmsResponse = http.get(`https://${__ENV.MY_HOSTNAME}/v1/films`);

    check(filmsResponse, {
        'status is 200 for get all films': (r) => r.status === 200,
    });

    let films = JSON.parse(filmsResponse.body);

    if (films.length === 0) {
        console.warn('No films available for testing.');
        return;
    }

    let randomFilm = films[Math.floor(Math.random() * films.length)];

    const url = `https://${__ENV.MY_HOSTNAME}/v1/films/${randomFilm.id}`;
    const res = http.get(url);

    check(res, {
        'status code 200 for get by id': (r) => r.status === 200
    });

    sleep(1);
}