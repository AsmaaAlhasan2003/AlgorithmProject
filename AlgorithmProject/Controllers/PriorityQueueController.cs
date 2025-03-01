using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
public class PriorityQueueController : Controller
{
    private static PriorityQueue _priorityQueue = new PriorityQueue();

    // ����� ���� ��� �������
    [HttpPost("enqueue")]
    public IActionResult Enqueue([FromBody] QueueItemDto itemDto)
    {
        _priorityQueue.Enqueue(itemDto.Value, itemDto.Priority);
        return Ok(new { message = "��� ����� ������ �����" });
    }

    // ����� ������ �� �������� ������
    [HttpPost("dequeue")]
    public IActionResult Dequeue()
    {
        if (_priorityQueue.IsEmpty())
            return BadRequest("������� ����");

        string item = _priorityQueue.Dequeue();
        return Ok(new { message = "��� ����� ������", value = item });
    }

    // ��� ������ �� �������� ������ ��� ������
    [HttpGet("peek")]
    public IActionResult Peek()
    {
        if (_priorityQueue.IsEmpty())
            return BadRequest("������� ����");

        string item = _priorityQueue.Peek();
        return Ok(new { value = item });
    }

    // ����� �� ���� �������
    [HttpGet("search-by-value/{value}")]
    public IActionResult SearchByValue(string value)
    {
        bool exists = _priorityQueue.SearchByValue(value);
        return Ok(new { found = exists });
    }

    // ����� �� ����� ���� ��������
    [HttpGet("search-by-priority/{priority}")]
    public IActionResult SearchByPriority(int priority)
    {
        List<string> results = _priorityQueue.SearchByPriority(priority);
        return Ok(new { results });
    }

    // ����� �� ���� �������� ������ ��������� ����
    [HttpGet("search-by-value-priority")]
    public IActionResult SearchByValueAndPriority([FromQuery] string value, [FromQuery] int priority)
    {
        bool exists = _priorityQueue.SearchByValueAndPriority(value, priority);
        return Ok(new { found = exists });
    }

    // ������ ��� ��� ��� ������� ������
    [HttpGet("is-empty")]
    public IActionResult IsEmpty()
    {
        return Ok(new { isEmpty = _priorityQueue.IsEmpty() });
    }
    public IActionResult Index()
    {
        return View();
    }
}

// ���� ���� �������� �� �������
public class QueueItemDto
{
    public string Value { get; set; }
    public int Priority { get; set; }
}
