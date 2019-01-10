export function decode(jwt) {
  console.log("DECODING...");

  var payload = extractPayload(jwt);
  console.log("extracted payload: " + payload);

  var tobase64 = atob(payload);
  console.log("base64: " + tobase64)

  var jwtobj = JSON.parse(tobase64);

  console.log("jwt: " + jwtobj.iat);
  var d = jwtobj.exp * 1000;
  console.log("date: " + d);
  var now = new Date();

  //
  var now_utc = Date.UTC(
    now.getUTCFullYear(),
    now.getUTCMonth(),
    now.getUTCDate(),
    now.getUTCHours(),
    now.getUTCMinutes(),
    now.getUTCSeconds()
  );
  //

  console.log("now: " + now_utc);
  console.log("d: " + d);
  var timeLeft = d - now_utc;
  console.log(
    "Expires in: " +
      new Date(timeLeft).getUTCHours() +
      ":" +
      new Date(timeLeft).getUTCMinutes()
  );
}

function extractPayload(str) {
  const payload = str.match(/\.(.*?)\./);
  return payload ? payload[1] : str;
}
