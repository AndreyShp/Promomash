const port = 6000;

module.exports = {
    port: port,
    main: `http://localhost:${port}`,
    regions: 'http://localhost:5010',
    users: 'http://localhost:5000'
};